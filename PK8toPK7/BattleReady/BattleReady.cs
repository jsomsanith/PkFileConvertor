using System;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using PKConverter.pokemons;
using PKHeX.Core;

namespace PKConverter.BattleReady
{
	public class BattleReady
	{
		public BattleReady()
		{
		}

		public static void buildBR()
		{
            string targetPath = @"/Users/jimmy.somsanith/Downloads/BR";
            string brDataFilePath = @"/Users/jimmy.somsanith/Documents/workspace/jsomsanith/Game8-extract/json/br-dex.json";
            string brDataJson = File.ReadAllText(brDataFilePath);
            BRData[] brData = JsonSerializer.Deserialize<BRData[]>(brDataJson);

            var path = @"/Users/jimmy.somsanith/Downloads/perso/SV_Shinies";
			var files = Directory.EnumerateFiles(path, "*", 0);

            foreach (var f in files)
			{
                var fi = new FileInfo(f);
                var data = File.ReadAllBytes(f);
				PK9 basePokemon = new PK9(data);

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

                    pokemon.Heal();
                    pokemon.RefreshChecksum();

                    var fileName = ((int)pokemon.Species) + (pokemon.IsShiny ? " ★" : "" ) + " - " + rawSpecieName + ("".Equals(build.name) ? ("#" + index) : (" - " + build.name));
                    var pokemonPath = targetPath + "/" + fileName;
                    LegalityAnalysis analysis = new LegalityAnalysis(pokemon);
                    File.WriteAllText(pokemonPath + ".report.txt", analysis.Report(true));
                    File.WriteAllBytes(pokemonPath + ".pk9", pokemon.DecryptedPartyData);
                }
                break;
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

