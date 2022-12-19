using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using PKConverter;

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
            new KeyValuePair<string, DateTime>("384 - Popularity Poll Rayquaza - FF680290FEE3", new DateTime(2012, 2, 10)),

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
            new KeyValuePair<string, DateTime>("350 ★ - VGC  2009 MILOTIC - DE242A0F0ED6", new DateTime(2009, 5, 9)),

            // Sun and Moon
            new KeyValuePair<string, DateTime>("658-01 - Special Demo Greninja - AE2800000021", new DateTime(2016, 10, 18)),
            new KeyValuePair<string, DateTime>("773 ★ - 2017 Gamestop Silvally - 35C33777AF56", new DateTime(2017, 11, 3)),
            new KeyValuePair<string, DateTime>("785 ★ - 7-11 Tapu Koko - F25778AC8F30", new DateTime(2017, 3, 17)),
            new KeyValuePair<string, DateTime>("718 ★ - 2018 Legends Zygarde - 58EFC5558FFC", new DateTime(2018, 6, 2)),            new KeyValuePair<string, DateTime>("243 - 2018 Legends Raikou - 8955847C4493", new DateTime(2018, 4, 12)),            new KeyValuePair<string, DateTime>("244 - 2018 Legends Entei - CCE67A04E70F", new DateTime(2018, 4, 12)),            new KeyValuePair<string, DateTime>("249 - 2018 Legends Lugia - 007E42DFEB37", new DateTime(2018, 11, 4)),            new KeyValuePair<string, DateTime>("250 - 2018 Legends Ho-Oh - A12DB28F88F2", new DateTime(2018, 11, 5)),            new KeyValuePair<string, DateTime>("380 - 2018 Legends Latias - CBF4F5F629E6", new DateTime(2018, 9, 2)),            new KeyValuePair<string, DateTime>("381 - 2018 Legends Latios - 77EC5693A410", new DateTime(2018, 9, 2)),            new KeyValuePair<string, DateTime>("382 - 2018 Legends Kyogre - 8685CC92C839", new DateTime(2018, 8, 6)),            new KeyValuePair<string, DateTime>("383 - 2018 Legends Groudon - DAE2D14656CE", new DateTime(2018, 8, 6)),            new KeyValuePair<string, DateTime>("483 - 2018 Legends Dialga - D39FAF87D112", new DateTime(2018, 2, 4)),            new KeyValuePair<string, DateTime>("484 - 2018 Legends Palkia - C984A4792146", new DateTime(2018, 2, 4)),            new KeyValuePair<string, DateTime>("485 - 2018 Legends Heatran - 841689EF095D", new DateTime(2018, 3, 16)),            new KeyValuePair<string, DateTime>("486 - 2018 Legends Regigigas - CC5579D4E5F0", new DateTime(2018, 3, 16)),            new KeyValuePair<string, DateTime>("641 - 2018 Legends Tornadus - 1F05C2B15E66", new DateTime(2018, 7, 13)),            new KeyValuePair<string, DateTime>("642 - 2018 Legends Thundurus - E364676A1277", new DateTime(2018, 7, 13)),            new KeyValuePair<string, DateTime>("643 - 2018 Legends Reshiram - 2A7EE03D3FEF", new DateTime(2018, 10, 20)),            new KeyValuePair<string, DateTime>("644 - 2018 Legends Zekrom - DB17274465A8", new DateTime(2018, 10, 20)),            new KeyValuePair<string, DateTime>("716 - 2018 Legends Xerneas - 693F3DF259D8", new DateTime(2018, 5, 4)),            new KeyValuePair<string, DateTime>("717 - 2018 Legends Yveltal - BCAE4BF88CA6", new DateTime(2018, 5, 4)),
            new KeyValuePair<string, DateTime>("803 ★ - Gamestop Poipole - D7E80DE94AD8", new DateTime(2018, 9, 17)),
            new KeyValuePair<string, DateTime>("786 ★ - Tapu Lele - 0C68CAE924D4", new DateTime(2018, 12, 18)),
            new KeyValuePair<string, DateTime>("787 ★ - Tapu Bulu - 939634B925AA", new DateTime(2019, 3, 19)),
            new KeyValuePair<string, DateTime>("785 ★ - Tapu Koko - 1DA5D1968747", new DateTime(2019, 8, 18)),
            new KeyValuePair<string, DateTime>("788 ★ - Tapu Fini - 0D94E7BC26ED", new DateTime(2019, 6, 11)),
            new KeyValuePair<string, DateTime>("648 - 2018 Worlds Meloetta - DF6D7662E9A2", new DateTime(2018, 8, 24)),

            // Pokemon XD
            new KeyValuePair<string, DateTime>("249 - XD001 Shadow Lugia - F73034146D90", new DateTime(2005, 12, 1)),

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
            new KeyValuePair<string, DateTime>("150 ★ - PCNYc Mewtwo - 6593A68B5B40", new DateTime(2002, 9, 27)),
            new KeyValuePair<string, DateTime>("243 ★ - PCNYc Raikou - 8C531E01A1D5", new DateTime(2002, 11, 15)),
            new KeyValuePair<string, DateTime>("244 ★ - PCNYc Entei - CFBA4C427DD1", new DateTime(2002, 11, 15)),
            new KeyValuePair<string, DateTime>("245 ★ - PCNYc Suicune - C931D60170DF", new DateTime(2002, 11, 15)),
            new KeyValuePair<string, DateTime>("249 ★ - PCNYb Lugia - A2AC2360ED45", new DateTime(2002, 11, 15)),
            new KeyValuePair<string, DateTime>("250 ★ - PCNYc Ho-Oh - 30AAF8F0704A", new DateTime(2002, 11, 15)),
            new KeyValuePair<string, DateTime>("359 - PCNYc 0461 Wish Absol - 1B60F7A9", new DateTime(2004, 7, 10)),
            new KeyValuePair<string, DateTime>("359 - PCNYc 0003 Spite Absol - 5990FB0A", new DateTime(2004, 7, 10)),
            new KeyValuePair<string, DateTime>("003 ★ - PCNYc Venusaur - 36AAF01376EC", new DateTime(2003, 2, 14)),
            new KeyValuePair<string, DateTime>("006 ★ - PCNYc Charizard - D124A5D91C3B", new DateTime(2003, 2, 14)),
            new KeyValuePair<string, DateTime>("009 ★ - PCNYc Blastoise - 4FEFD1614F3B", new DateTime(2003, 2, 14)),
        };

        static void Main(string[] args)
        {
            //fixGen8Date(args);
            buildGen9(args);
        }

        private static void buildGen9(string[] args)
        {
            LocalizeUtil.InitializeStrings("en");

            PK9 ceruledge = Ceruledge.bestBuild();
            print("/Users/jimmy.somsanith/Downloads/Ceruledge.best.details.txt", ceruledge);
            checkLegality("/Users/jimmy.somsanith/Downloads/Ceruledge.best.report.txt", ceruledge);
            File.WriteAllBytes("/Users/jimmy.somsanith/Downloads/Ceruledge.best.pk9", ceruledge.DecryptedPartyData);

            PK9 ceruledgeTera = Ceruledge.teraBuild();
            print("/Users/jimmy.somsanith/Downloads/Ceruledge.tera.details.txt", ceruledgeTera);
            checkLegality("/Users/jimmy.somsanith/Downloads/Ceruledge.tera.report.txt", ceruledgeTera);
            File.WriteAllBytes("/Users/jimmy.somsanith/Downloads/Ceruledge.tera.pk9", ceruledgeTera.DecryptedPartyData);

            PK9 ceruledgeTera2 = Ceruledge.teraBuildForCinderace();
            print("/Users/jimmy.somsanith/Downloads/Ceruledge.tera2.details.txt", ceruledgeTera2);
            checkLegality("/Users/jimmy.somsanith/Downloads/Ceruledge.tera2.report.txt", ceruledgeTera2);
            File.WriteAllBytes("/Users/jimmy.somsanith/Downloads/Ceruledge.tera2.pk9", ceruledgeTera2.DecryptedPartyData);
        }



        private static void fixGen8Date(string[] args)
        {
            LocalizeUtil.InitializeStrings("en");
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
                PK9 pk9 = null;

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
                    case ".pk9":
                        pk9 = new PK9(data);
                        break;
                    default:
                        continue;
                }

                //Console.WriteLine("PK8 Species: " + pk8.Species);
                //Console.WriteLine("PK8 ID: " + pk8.DisplayTID);
                //Console.WriteLine("PK8 OT: " + pk8.OT_Name);
                //Console.WriteLine("PK8 TID: " + pk8.TID);
                //Console.WriteLine("PK8 Shiny: " + pk8.IsShiny);
                //Console.WriteLine("PK8 Language: " + pk8.Language);
                //Console.WriteLine("PK8 valid: " + pk8.Valid);

                if (pk9 != null)
                {
                    print(f.Replace(fi.Extension, ".details.txt"), pk9);
                    checkLegality(f.Replace(fi.Extension, ".report.txt"), pk9);
                }

                if (pk8 != null)
                {
                    fixDate(f, pk8);
                    fixCurrentHandler(pk8);
                    //setOwnOT(pk8);
                    //fixTID(pk8);
                    // Uncomment to make it shiny
                    //pk8.SetShiny();
                    pk8.RefreshChecksum();

                    LegalityAnalysis analysis = new LegalityAnalysis(pk8);
                    File.WriteAllText(f.Replace(fi.Extension, ".report.txt"), analysis.Report(true));
                    File.WriteAllBytes(f.Replace(fi.Extension, ".pk8"), pk8.DecryptedPartyData);
                    //File.WriteAllBytes(f.Replace(fi.Extension, ".pk8"), pk8.DecryptedBoxData);
                }

            }

        }

        private static void fixTID(PK8 pk8)
        {
            if(pk8.TID != pk8.DisplayTID)
            {
                Console.WriteLine("Trainer ID different from DisplayTID, keep as is");
                return;
            }
            var TIDBeforeUpdate = pk8.TID;
            pk8.TID = 52954;
            pk8.SID = 9949;
            Console.WriteLine("Updated TID: " + TIDBeforeUpdate + " --> " + pk8.TID);
        }

        private static void fixCurrentHandler(PK8 pk8)
        {
            pk8.CurrentHandler = 1;
            Console.WriteLine("Fix current handler");
        }

        private static void setOwnOT(PK8 pk8)
        {
            var previousOT = pk8.OT_Name;
            pk8.OT_Name = "Jimmy";
            Console.WriteLine("Set OT " + previousOT + " --> Jimmy");

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

        private static void print(string fileName, PK9 pk9)
        {
            var details = "";
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(pk9))
            {
                try
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(pk9);
                    //Console.WriteLine("{0}={1}", name, value);
                    details += name + "=" + value + "\n";
                }
                catch (Exception e) { }
            }

            File.WriteAllText(fileName, details);

        }

        private static void checkLegality(string fileName, PK9 pk9)
        {
            LegalityAnalysis analysis = new LegalityAnalysis(pk9);
            File.WriteAllText(fileName, analysis.Report(true));
        }
    }
}


//foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(pk2))
//{
//    string name = descriptor.Name;
//    object value = descriptor.GetValue(pk2);
//    Console.WriteLine("{0}={1}", name, value);
//}
