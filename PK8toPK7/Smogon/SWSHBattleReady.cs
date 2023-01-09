using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using PKConverter.Utils;
using PKHeX.Core;

namespace PKConverter.Smogon
{
	public class SWSHBattleReady
	{
		public static void build() 
		{
            string brDataFilePath = @"/Users/jimmy.somsanith/Documents/workspace/jsomsanith/Smogon-extract/result/ss.json";
            string targetPath = @"/Users/jimmy.somsanith/Downloads/swsh/BR";
            string targetShinyPath = @"/Users/jimmy.somsanith/Downloads/swsh/SBR";
            string legalDexPath = @"/Users/jimmy.somsanith/Downloads/perso/SWSH-dex";

            Directory.CreateDirectory(targetPath);
            Directory.CreateDirectory(targetShinyPath);

            // keep a list of pokemon done to avoid building the same multiple times
            List<ushort> speciesDone = new List<ushort>();
            string brDataJson = File.ReadAllText(brDataFilePath);
            BRData[] brData = JsonSerializer.Deserialize<BRData[]>(brDataJson);

            string showdown = "";
            string shinyShowdown = "";

			var files = Directory.EnumerateFiles(legalDexPath, "*", 0);
            files =  files.OrderBy(s => Int16.Parse(Regex.Match(s, @"\d+").Value));
            foreach (var f in files)
			{
                // read PK files from legal dex
                var fi = new FileInfo(f);
                var data = File.ReadAllBytes(f);
                PK8 basePokemon = new PK8(data);

                // pokemon already done ?
                if (speciesDone.Contains(basePokemon.Species))
                {
                    continue;
                }
                speciesDone.Add(basePokemon.Species);

                // find build for this pokemon
                var gameString = new GameStrings("en");
                string rawSpecieName = gameString.specieslist[basePokemon.Species];
                BRData brPkmData = Array.Find(
					brData,
                    pkm => pkm.name.Equals(rawSpecieName, StringComparison.Ordinal)
				);

				if(brPkmData == null)
				{
					continue;	
                }

                Console.WriteLine(rawSpecieName + ": " + brPkmData.builds.Length + " build(s) found");

                char multiIndexLetter = (char)65;
                int multiIndexNumber = 1;
                for (int index = 0; index < brPkmData.builds.Length; index++)
                {
                    BRBuild build = brPkmData.builds[index];

                    // not a valid build
                    if (build.nature == null || build.ability == null)
                    {
                        continue;
                    }

                    Console.WriteLine();
					Console.WriteLine(rawSpecieName + "#" + index + "(" + build.name + ")" +  "-------------------------");
                    PK8 pokemon = (PK8)basePokemon.Clone();

                    Nature nature = (Nature)Nature.Parse(typeof(Nature), build.nature);
                    pokemon.SetNature((int)nature);
					Console.WriteLine("Nature: " + nature);

                    Ability ability = (Ability)Ability.Parse(typeof(Ability), strToEnumName(build.ability));
                    pokemon.SetAbility((int)ability);
					Console.WriteLine("Ability: " + ability);

                    var evs = new int[] { build.evs.HP, build.evs.ATK, build.evs.DEF, build.evs.SPE, build.evs.SPA, build.evs.SPD };
                    pokemon.SetEVs(evs);
					Console.WriteLine("EVs: " + string.Join(",", evs));

                    int itemId = Array.FindIndex(gameString.itemlist, itemName => itemName == build.heldItem);
                    pokemon.HeldItem = itemId;
					Console.WriteLine("Held item: " + build.heldItem + "#" + itemId);

                    var move1 = (Move)Move.Parse(typeof(Move), strToEnumName(build.moveset[0]));
                    var move2 = build.moveset.Length > 1 ? (Move)Move.Parse(typeof(Move), strToEnumName(build.moveset[1])) : Move.None;
                    var move3 = build.moveset.Length > 2 ? (Move)Move.Parse(typeof(Move), strToEnumName(build.moveset[2])) : Move.None;
                    var move4 = build.moveset.Length > 3 ? (Move)Move.Parse(typeof(Move), strToEnumName(build.moveset[3])) : Move.None;
                    var moves = new ushort[] { (ushort)move1, (ushort)move2, (ushort)move3, (ushort)move4 };
                    setMoves(pokemon, moves);
					Console.WriteLine("moves: " + move1 + ", " + move2 + ", " + move3 + ", " + move4);

                    pokemon.OT_Name = "Pokepark"; //"CasualTea";
                    pokemon.MaximizeLevel();
                    pokemon.SetRandomIVs(6);
                    pokemon.HT_HP = false;
                    pokemon.HT_ATK = false;
                    pokemon.HT_DEF = false;
                    pokemon.HT_SPE = false;
                    pokemon.HT_SPA = false;
                    pokemon.HT_SPD = false;
                    pokemon.Heal();
                    pokemon.SetMaximumPPUps();

                    pokemon.SetIsShiny(false);
                    pokemon.RefreshChecksum();

                    // pokepark default format
                    //var fileName = ((int)pokemon.Species) + (pokemon.IsShiny ? " ★" : "" ) + " - " + rawSpecieName + (("".Equals(build.name) || build.name == null) ? ("#" + index) : (" - " + build.name));
                    // casualtea format
                    //var fileName = "BR" + rawSpecieName + (brPkmData.builds.Length > 1 ? multiIndexNumber : "");
                    // pokepark lycanroc format
                    var pkmCode = "BR" + ((int)pokemon.Species) + (brPkmData.builds.Length > 1 ? ("-" + multiIndexLetter) : "");
                    var fileName = pkmCode + " " + rawSpecieName;
                    var pokemonPath = targetPath + "/" + fileName;
                    try
                    {
                        PKUtils.checkLegality(pokemonPath + ".report.txt", pokemon);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("NOT VALID");
                        continue;
                    }
                    File.WriteAllBytes(pokemonPath + ".pk8", pokemon.DecryptedPartyData);

                    // casualtea format
                    //showdown += fileName + " " + (pokemon.Gender == (int)Gender.Male ? "(M) " : pokemon.Gender == (int)Gender.Female ? "(F) " : "") + "@ " + gameString.itemlist[pokemon.HeldItem] + "\n";
                    // pokepark format
                    showdown += pkmCode + " (" + rawSpecieName + ") " + (pokemon.Gender == (int)Gender.Male ? "(M) " : pokemon.Gender == (int)Gender.Female ? "(F) " : "") + "@ " + gameString.itemlist[pokemon.HeldItem] + "\n";
                    showdown += "Ability: " + gameString.abilitylist[pokemon.Ability] + "\n";
                    showdown += "Level: " + pokemon.CurrentLevel + "\n";
                    showdown += "EVs: " + build.evs.HP + " HP / " + build.evs.ATK + " Atk / " + build.evs.DEF + " Def / " + build.evs.SPA + " SpA / " + build.evs.SPD + " SpD / " + build.evs.SPE + " Spe\n";
                    showdown += "Shiny: No\n";
                    showdown += nature + " Nature\n";
                    showdown += "- " + gameString.movelist[(int)move1] + "\n";
                    if (move2 != Move.None)
                    {
                        showdown += "- " + gameString.movelist[(int)move2] + "\n";
                    }
                    if (move3 != Move.None)
                    {
                        showdown += "- " + gameString.movelist[(int)move3] + "\n";
                    }
                    if (move4 != Move.None)
                    {
                        showdown += "- " + gameString.movelist[(int)move4] + "\n";
                    }
                    showdown += "\n";

                    pokemon.SetIsShiny(true);
                    pokemon.SetShinySID(Shiny.AlwaysSquare);
                    pokemon.RefreshChecksum();

                    pkmCode = "SBR" + ((int)pokemon.Species) + (brPkmData.builds.Length > 1 ? ("-" + multiIndexLetter) : "");
                    // casualtea
                    //fileName = "BR" + rawSpecieName + (brPkmData.builds.Length > 1 ? multiIndex : "");
                    // pokepark lycanrock format
                    fileName = pkmCode + " " + rawSpecieName;
                    pokemonPath = targetShinyPath + "/" + fileName;
                    try
                    {
                        PKUtils.checkLegality(pokemonPath + ".report.txt", pokemon);
                        File.WriteAllBytes(pokemonPath + ".pk8", pokemon.DecryptedPartyData);

                        // casualtea
                        //shinyShowdown += fileName + " " + (pokemon.Gender == (int)Gender.Male ? "(M) " : pokemon.Gender == (int)Gender.Female ? "(F) " : "") + "@ " + gameString.itemlist[pokemon.HeldItem] + "\n";
                        shinyShowdown += pkmCode + " (" + rawSpecieName + ") " + (pokemon.Gender == (int)Gender.Male ? "(M) " : pokemon.Gender == (int)Gender.Female ? "(F) " : "") + "@ " + gameString.itemlist[pokemon.HeldItem] + "\n";
                        shinyShowdown += "Ability: " + gameString.abilitylist[pokemon.Ability] + "\n";
                        shinyShowdown += "Level: " + pokemon.CurrentLevel + "\n";
                        shinyShowdown += "EVs: " + build.evs.HP + " HP / " + build.evs.ATK + " Atk / " + build.evs.DEF + " Def / " + build.evs.SPA + " SpA / " + build.evs.SPD + " SpD / " + build.evs.SPE + " Spe\n";
                        shinyShowdown += "Shiny: Yes\n";
                        shinyShowdown += nature + " Nature\n";
                        shinyShowdown += "- " + gameString.movelist[(int)move1] + "\n";
                        if (move2 != Move.None)
                        {
                            shinyShowdown += "- " + gameString.movelist[(int)move2] + "\n";
                        }
                        if (move3 != Move.None)
                        {
                            shinyShowdown += "- " + gameString.movelist[(int)move3] + "\n";
                        }
                        if (move4 != Move.None)
                        {
                            shinyShowdown += "- " + gameString.movelist[(int)move4] + "\n";
                        }
                        shinyShowdown += "\n";
                    } catch(Exception e) { }

                    multiIndexLetter++;
                    multiIndexNumber++;
                }

                var showdownPath = targetPath + "/showdown.txt";
                var shinyShowdownPath = targetShinyPath + "/shinyShowdown.txt";
                File.WriteAllText(showdownPath, showdown);
                File.WriteAllText(shinyShowdownPath, shinyShowdown);
            }

        }

        public static void setMoves(PK8 newPokemon, ushort[] moves)
        {
            newPokemon.FixMoves();
            newPokemon.SetMoves(new Moveset(moves[0], moves[1], moves[2], moves[3]));
            TechnicalRecordApplicator.SetRecordFlags(newPokemon, moves);
        }

        private static string strToEnumName(string s)
        {
            return Regex.Replace(s, @"\s+", "").Replace("-", "").Replace("'", "");
        }
    }
}

