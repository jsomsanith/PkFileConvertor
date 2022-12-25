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

namespace PKConverter.BattleReady
{
	public class BattleReady
	{
		public static void buildBR()
		{
            List<ushort> speciesDone = new List<ushort>();
            string targetPath = @"/Users/jimmy.somsanith/Downloads/BR";
            string targetShinyPath = @"/Users/jimmy.somsanith/Downloads/SBR";
            string brDataFilePath = @"/Users/jimmy.somsanith/Documents/workspace/jsomsanith/Game8-extract/json/br-dex.json";
            string brDataJson = File.ReadAllText(brDataFilePath);
            BRData[] brData = JsonSerializer.Deserialize<BRData[]>(brDataJson);

            string showdown = "";
            string shinyShowdown = "";

            var path = @"/Users/jimmy.somsanith/Downloads/perso/SV_Shinies";
			var files = Directory.EnumerateFiles(path, "*", 0);
            files =  files.OrderBy(s => Int16.Parse(Regex.Match(s, @"\d+").Value));
            foreach (var f in files)
			{
                var fi = new FileInfo(f);
                var data = File.ReadAllBytes(f);
				PK9 basePokemon = new PK9(data);

                if(speciesDone.Contains(basePokemon.Species))
                {
                    continue;
                }
                speciesDone.Add(basePokemon.Species);

                var gameString = new GameStrings("en");
                string rawSpecieName = gameString.specieslist[basePokemon.Species];
                //            var name = Regex.Replace(rawSpecieName, @"\s+", "");
                //name = Regex.Replace(name, @"-", "");

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
                    Console.WriteLine();
					Console.WriteLine(rawSpecieName + "#" + index + "(" + build.name + ")" +  "-------------------------");
                    PK9 pokemon = (PK9)basePokemon.Clone();

                    Nature nature = (Nature)Nature.Parse(typeof(Nature), build.nature);
                    pokemon.SetNature((int)nature);
					Console.WriteLine("Nature: " + nature);

                    Ability ability = (Ability)Ability.Parse(typeof(Ability), build.ability);
                    pokemon.SetAbility((int)ability);
					Console.WriteLine("Ability: " + ability);

                    var evs = new int[] { build.evs.HP, build.evs.ATK, build.evs.DEF, build.evs.SPE, build.evs.SPA, build.evs.SPD };
                    pokemon.SetEVs(evs);
					Console.WriteLine("EVs: " + string.Join(",", evs));

                    MoveType teraType = (MoveType)MoveType.Parse(typeof(MoveType), build.teraType);
                    pokemon.SetTeraType(teraType);
					Console.WriteLine("Tera type: " + teraType);

                    int itemId = Array.FindIndex(gameString.itemlist, itemName => itemName == build.heldItem);
                    pokemon.HeldItem = itemId;
					Console.WriteLine("Held item: " + build.heldItem + "#" + itemId);
                    
                    var move1 = (Move)Move.Parse(typeof(Move), build.moveset[0]);
                    var move2 = (Move)Move.Parse(typeof(Move), build.moveset[1]);
                    var move3 = (Move)Move.Parse(typeof(Move), build.moveset[2]);
                    var move4 = (Move)Move.Parse(typeof(Move), build.moveset[3]);
                    var moves = new ushort[] { (ushort)move1, (ushort)move2, (ushort)move3, (ushort)move4 };
                    setMoves(pokemon, moves);
					Console.WriteLine("moves: " + move1 + ", " + move2 + ", " + move3 + ", " + move4);

                    pokemon.OT_Name = "Pokepark"; //"CasualTea";
                    pokemon.MaximizeLevel();
                    pokemon.SetRandomIVs(6);
                    pokemon.Heal();
                    pokemon.SetMaximumPPUps();

                    pokemon.SetIsShiny(false);
                    pokemon.RefreshChecksum();

                    // pokepark default
                    //var fileName = ((int)pokemon.Species) + (pokemon.IsShiny ? " ★" : "" ) + " - " + rawSpecieName + (("".Equals(build.name) || build.name == null) ? ("#" + index) : (" - " + build.name));
                    // casualtea
                    //var fileName = "BR" + rawSpecieName + (brPkmData.builds.Length > 1 ? multiIndexNumber : "");
                    var pkmCode = "BR" + ((int)pokemon.Species) + (brPkmData.builds.Length > 1 ? ("-" + multiIndexLetter) : "");
                    var fileName = pkmCode + " " + rawSpecieName;
                    var pokemonPath = targetPath + "/" + fileName;
                    PKUtils.checkLegality(pokemonPath + ".report.txt", pokemon);
                    File.WriteAllBytes(pokemonPath + ".pk9", pokemon.DecryptedPartyData);

                    // casualtea
                    //showdown += fileName + " " + (pokemon.Gender == (int)Gender.Male ? "(M) " : pokemon.Gender == (int)Gender.Female ? "(F) " : "") + "@ " + gameString.itemlist[pokemon.HeldItem] + "\n";
                    showdown += pkmCode + " (" + rawSpecieName + ") " + (pokemon.Gender == (int)Gender.Male ? "(M) " : pokemon.Gender == (int)Gender.Female ? "(F) " : "") + "@ " + gameString.itemlist[pokemon.HeldItem] + "\n";
                    showdown += "Ability: " + gameString.abilitylist[pokemon.Ability] + "\n";
                    showdown += "Tera Type: " + teraType + "\n";
                    showdown += "Level: " + pokemon.CurrentLevel + "\n";
                    showdown += "EVs: " + build.evs.HP + " HP / " + build.evs.ATK + " Atk / " + build.evs.DEF + " Def / " + build.evs.SPA + " SpA / " + build.evs.SPD + " SpD / " + build.evs.SPE + " Spe\n";
                    showdown += "Shiny: No\n";
                    showdown += nature + " Nature\n";
                    showdown += "- " + gameString.movelist[(int)move1] + "\n";
                    showdown += "- " + gameString.movelist[(int)move2] + "\n";
                    showdown += "- " + gameString.movelist[(int)move3] + "\n";
                    showdown += "- " + gameString.movelist[(int)move4] + "\n\n";

                    pokemon.SetIsShiny(true);
                    pokemon.SetShinySID(Shiny.AlwaysSquare);
                    pokemon.RefreshChecksum();

                    pkmCode = "SBR" + ((int)pokemon.Species) + (brPkmData.builds.Length > 1 ? ("-" + multiIndexLetter) : "");
                    fileName = pkmCode + " " + rawSpecieName;
                    // casualtea
                    //fileName = "BR" + rawSpecieName + (brPkmData.builds.Length > 1 ? multiIndex : "");
                    pokemonPath = targetShinyPath + "/" + fileName;
                    try
                    {
                        PKUtils.checkLegality(pokemonPath + ".report.txt", pokemon);
                        File.WriteAllBytes(pokemonPath + ".pk9", pokemon.DecryptedPartyData);

                        // casualtea
                        //shinyShowdown += fileName + " " + (pokemon.Gender == (int)Gender.Male ? "(M) " : pokemon.Gender == (int)Gender.Female ? "(F) " : "") + "@ " + gameString.itemlist[pokemon.HeldItem] + "\n";
                        shinyShowdown += pkmCode + " (" + rawSpecieName + ") " + (pokemon.Gender == (int)Gender.Male ? "(M) " : pokemon.Gender == (int)Gender.Female ? "(F) " : "") + "@ " + gameString.itemlist[pokemon.HeldItem] + "\n";
                        shinyShowdown += "Ability: " + gameString.abilitylist[pokemon.Ability] + "\n";
                        shinyShowdown += "Tera Type: " + teraType + "\n";
                        shinyShowdown += "Level: " + pokemon.CurrentLevel + "\n";
                        shinyShowdown += "EVs: " + build.evs.HP + " HP / " + build.evs.ATK + " Atk / " + build.evs.DEF + " Def / " + build.evs.SPA + " SpA / " + build.evs.SPD + " SpD / " + build.evs.SPE + " Spe\n";
                        shinyShowdown += "Shiny: Yes\n";
                        shinyShowdown += nature + " Nature\n";
                        shinyShowdown += "- " + gameString.movelist[(int)move1] + "\n";
                        shinyShowdown += "- " + gameString.movelist[(int)move2] + "\n";
                        shinyShowdown += "- " + gameString.movelist[(int)move3] + "\n";
                        shinyShowdown += "- " + gameString.movelist[(int)move4] + "\n\n";
                    } catch(Exception e) { }

                    multiIndexLetter++;
                    multiIndexNumber++;
                }

                var showdownPath = targetPath + "/showdown.txt";
                var shinyShowdownPath = targetShinyPath + "/shinySowdown.txt";
                File.WriteAllText(showdownPath, showdown);
                File.WriteAllText(shinyShowdownPath, shinyShowdown);
            }

        }

        public static void setMoves(PK9 newPokemon, ushort[] moves)
        {
            newPokemon.FixMoves();
            newPokemon.SetMoves(new Moveset(moves[0], moves[1], moves[2], moves[3]));
            TechnicalRecordApplicator.SetRecordFlags(newPokemon, moves);
        }
    }
}

