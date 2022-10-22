using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace PK8toPK7
{
    class Program
    {
        static KeyValuePair<string, DateTime>[] eventDates =  {
            // Black and White
            new KeyValuePair<string, DateTime>("025 - Battle Tour PIKACHU - B638", new DateTime(1998, 7, 19)),
            new KeyValuePair<string, DateTime>("249 ★ - LUGIA - 19F9", new DateTime(2002, 11, 21)),
            new KeyValuePair<string, DateTime>("250 ★ - HO-OH - B6A5", new DateTime(2002, 11, 21)),
            new KeyValuePair<string, DateTime>("243 ★ - WINTER 2011 RAIKOU - BD1E74550788", new DateTime(2011, 2, 7)),
            new KeyValuePair<string, DateTime>("244 ★ - WINTER 2011 ENTEI - F8D51382179C", new DateTime(2011, 2, 14)),
            new KeyValuePair<string, DateTime>("245 ★ - WINTER 2011 SUICUNE - 4FB87AE975F0", new DateTime(2011, 2, 21)),
            new KeyValuePair<string, DateTime>("491 - TOYS R US Darkrai - 3FC882B2A4F7", new DateTime(2011, 11, 14)),

            // Ruby Sapphire Emerald
            new KeyValuePair<string, DateTime>("385 - WISH MAKER JIRACHI - 267A185242FB", new DateTime(2003, 12, 1)),
            new KeyValuePair<string, DateTime>("359 - PCN 5 ANNIV ABSOL タマゴ - B17684E66F4B", new DateTime(2004, 7, 10)),

            // Omega Ruby and Alpha Sapphire
            new KeyValuePair<string, DateTime>("374 ★ - ORAS Early Purchase Beldum - 7D9AE4ACE9D0", new DateTime(2014, 11, 21)),
            new KeyValuePair<string, DateTime>("250 ★ - PCN Kyoto Ho-Oh - 4BBB6B101819", new DateTime(2016, 3, 16)),
            new KeyValuePair<string, DateTime>("658 - Pokemon Movie Greninja - C91E94F80139", new DateTime(2016, 7, 16)),

            // X Y
            new KeyValuePair<string, DateTime>("150 ★ - PLAY 2016 Mewtwo - 9E4BAF26BE4D", new DateTime(2016, 7, 26)),

            // Diamond Pearl Platinium
            new KeyValuePair<string, DateTime>("149 - STRONGEST POKEMON DRAGONITE カイリュー - B7540E2CFBFC", new DateTime(2018, 1, 15)),

            // Sun and Moon
            new KeyValuePair<string, DateTime>("658-01 - Special Demo Greninja - AE2800000021", new DateTime(2016, 10, 18)),
            new KeyValuePair<string, DateTime>("773 ★ - 2017 Gamestop Silvally - 35C33777AF56", new DateTime(2017, 11, 3)),
            new KeyValuePair<string, DateTime>("785 ★ - 7-11 Tapu Koko - F25778AC8F30", new DateTime(2017, 3, 17)),
            new KeyValuePair<string, DateTime>("785 ★ - Tapu Koko - 1DA5D1968747", new DateTime(2019, 8, 18)),
            new KeyValuePair<string, DateTime>("803 ★ - Gamestop Poipole - D7E80DE94AD8", new DateTime(2018, 9, 17)),
            new KeyValuePair<string, DateTime>("786 ★ - Tapu Lele - 0C68CAE924D4", new DateTime(2018, 12, 18)),
            new KeyValuePair<string, DateTime>("787 ★ - Tapu Bulu - 939634B925AA", new DateTime(2019, 3, 19)),
            new KeyValuePair<string, DateTime>("788 ★ - Tapu Fini - 0D94E7BC26ED", new DateTime(2019, 6, 11)),

            // SWSH
            new KeyValuePair<string, DateTime>("807 ★ - HOME Zeraora - 946C00000000", new DateTime(2020, 6, 30)),
            new KeyValuePair<string, DateTime>("591 ★ - KOR Champ Amoongus뽀록나 - 55D5ADEEC8CD", new DateTime(2020, 8, 9)),
            new KeyValuePair<string, DateTime>("113 - MrDonut 50 Chansey ラッキー - EC79E88CE680", new DateTime(2020, 12, 4)),
            new KeyValuePair<string, DateTime>("849 ★ - PTCG Tie-In Toxtricity - AEE676750696", new DateTime(2021, 2, 19)),
            new KeyValuePair<string, DateTime>("025 - Pokémon25 Pikachu - 20B475DCBD30", new DateTime(2021, 2, 25)),
            new KeyValuePair<string, DateTime>("324 - JPN Champs Torkoal コータス - 8C653F3F13A4", new DateTime(2021, 7, 18)),
            new KeyValuePair<string, DateTime>("474 - KOR Champ Porygon-Z 폴리곤Z - 221B1C415E61", new DateTime(2021, 8, 21)),
            new KeyValuePair<string, DateTime>("251 ★ - Global Jungle Celebi - 29C5F2026F12", new DateTime(2021, 10, 7)),
            new KeyValuePair<string, DateTime>("440 - PCJPN Happiny - EFA0AA042D3D", new DateTime(2021, 11, 1)),
            new KeyValuePair<string, DateTime>("302 - JPN Champ Sableye ヤミラミ - 03A14D84F8FB", new DateTime(2022, 6, 11)),
            new KeyValuePair<string, DateTime>("861 - KOR Grimmsnarl 오롱털 - 0425A0E0E274", new DateTime(2022, 6, 11)),
            new KeyValuePair<string, DateTime>("035 ★ - Singapore Clefairy - 228B2B2D8625", new DateTime(2022, 6, 18)),
            new KeyValuePair<string, DateTime>("025-09 - JPN Movie Pikachu ピカチュウ - C0FB72ECFAD7", new DateTime(2022, 8, 11)),
            new KeyValuePair<string, DateTime>("882 - JPN PKM Masters Dracovish ウオノラゴン - 068EF2CE51F0", new DateTime(2022, 8, 12)),
            new KeyValuePair<string, DateTime>("149 - JPN Ash Dragonite カイリュー - F0B26076162C", new DateTime(2022, 8, 26)),
            new KeyValuePair<string, DateTime>("094 - JPN Ash Gengar ゲンガー - 8DF887D86E91", new DateTime(2022, 9, 2)),
            new KeyValuePair<string, DateTime>("035 - PCJPN Clefairy ピッピ - 181F2C1296A7", new DateTime(2022, 9, 3)),
            new KeyValuePair<string, DateTime>("865 - JPN Ash Sirfetch_d ネギガナイト - 92901A63360E", new DateTime(2022, 9, 9)),
            new KeyValuePair<string, DateTime>("448 - JPN Ash Lucario ルカリオ - 5E21FF79491D", new DateTime(2022, 9, 16)),

            // PCNY
            new KeyValuePair<string, DateTime>("249 ★ - PCNYb Lugia - A2AC2360ED45", new DateTime(2002, 11, 15)),
            new KeyValuePair<string, DateTime>("359 - PCNYc 0461 Wish Absol - 1B60F7A9", new DateTime(2004, 7, 10)),
            new KeyValuePair<string, DateTime>("359 - PCNYc 0003 Spite Absol - 5990FB0A", new DateTime(2004, 7, 10)),
            new KeyValuePair<string, DateTime>("003 ★ - PCNYc Venusaur - 36AAF01376EC", new DateTime(2003, 2, 14)),
            new KeyValuePair<string, DateTime>("006 ★ - PCNYc Charizard - D124A5D91C3B", new DateTime(2003, 2, 14)),
            new KeyValuePair<string, DateTime>("009 ★ - PCNYc Blastoise - 4FEFD1614F3B", new DateTime(2003, 2, 14)),
        };

        static void Main(string[] args)
        {
            var path = @"/Users/jimmy.somsanith/Downloads";
            var files = Directory.EnumerateFiles(path, "*", 0);

            foreach (var f in files)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("New file: " + f);
                var fi = new FileInfo(f);

                var data = File.ReadAllBytes(f);
                PK1 pk1 = null;
                PK2 pk2 = null;
                PK3 pk3 = null;
                PK4 pk4 = null;
                PK5 pk5 = null;
                PK6 pk6 = null;
                PK7 pk7 = null;
                PK8 pk8 = null;

                switch(fi.Extension)
                {
                    case ".pk1":
                        pk1 = new PK1(data);
                        Console.WriteLine("Original Species: " + pk1.Species);
                        Console.WriteLine("Original met date: " + pk1.MetDate);
                        pk7 = pk1.ConvertToPK7();
                        pk8 = pk7.ConvertToPK8();
                        break;
                    case ".pk2":
                        pk2 = new PK2(data);
                        Console.WriteLine("Original Species: " + pk2.Species);
                        Console.WriteLine("Original met date: " + pk2.MetDate);
                        pk7 = pk2.ConvertToPK7();
                        pk8 = pk7.ConvertToPK8();
                        break;
                    case ".pk3":
                        pk3 = new PK3(data);
                        Console.WriteLine("Original met date: " + pk3.MetDate);
                        pk4 = pk3.ConvertToPK4();
                        pk5 = pk4.ConvertToPK5();
                        pk6 = pk5.ConvertToPK6();
                        pk7 = pk6.ConvertToPK7();
                        pk8 = pk7.ConvertToPK8();
                        break;
                    case ".pk4":
                        pk4 = new PK4(data);
                        Console.WriteLine("Original met date: " + pk4.MetDate);
                        pk5 = pk4.ConvertToPK5();
                        pk6 = pk5.ConvertToPK6();
                        pk7 = pk6.ConvertToPK7();
                        pk8 = pk7.ConvertToPK8();
                        break;
                    case ".pk5":
                        pk5 = new PK5(data);
                        Console.WriteLine("Original met date: " + pk5.MetDate);
                        pk6 = pk5.ConvertToPK6();
                        pk7 = pk6.ConvertToPK7();
                        pk8 = pk7.ConvertToPK8();
                        break;
                    case ".pk6":
                        pk6 = new PK6(data);
                        Console.WriteLine("Original met date: " + pk6.MetDate);
                        pk7 = pk6.ConvertToPK7();
                        pk8 = pk7.ConvertToPK8();
                        break;
                    case ".pk7":
                        pk7 = new PK7(data);
                        Console.WriteLine("Original met date: " + pk7.MetDate);
                        pk8 = pk7.ConvertToPK8();
                        break;
                    case ".pk8":
                        pk8 = new PK8(data);
                        Console.WriteLine("Original met date: " + pk8.MetDate);
                        break;
                    default:
                        continue;
                }
                
                Console.WriteLine("PK8 Species: " + pk8.Species);
                Console.WriteLine("PK8 ID: " + pk8.DisplayTID);
                Console.WriteLine("PK8 OT: " + pk8.OT_Name);
                Console.WriteLine("PK8 Shiny: " + pk8.IsShiny);
                Console.WriteLine("PK8 Language: " + pk8.Language);
                Console.WriteLine("PK8 valid: " + pk8.Valid);

                if (pk8 != null)
                {
                    fixDate(f, pk8);
                    
                    // Uncomment to make it shiny
                    //pk8.SetShiny();
                    File.WriteAllBytes(f.Replace(fi.Extension, ".pk8"), pk8.DecryptedPartyData);
                    //File.WriteAllBytes(f.Replace(fi.Extension, ".pk8"), pk8.DecryptedBoxData);
                }

            }

        }

        private static void fixDate(string fileNameWithExtension, PK8 pk8)
        {
            var fileName = Path.GetFileNameWithoutExtension(fileNameWithExtension);
            Console.WriteLine("Search date for " + fileName);
            var eventDateEntry = Array.Find<KeyValuePair<string, DateTime>>(eventDates, kv => kv.Key.Equals(fileName));

            if(eventDateEntry.Equals(default(KeyValuePair<string, DateTime>)))
            {
                Console.WriteLine("No date found, keep the original one: " + pk8.MetDate);
                return;
            }

            var dateBeforeUpdate = pk8.MetDate;
            pk8.MetDate = eventDateEntry.Value;
            Console.WriteLine(eventDateEntry);
            Console.WriteLine("Updated met date: " + dateBeforeUpdate + " --> " + pk8.MetDate);

        }
    }
}


//foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(pk2))
//{
//    string name = descriptor.Name;
//    object value = descriptor.GetValue(pk2);
//    Console.WriteLine("{0}={1}", name, value);
//}
