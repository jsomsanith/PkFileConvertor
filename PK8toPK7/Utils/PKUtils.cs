using System;
using System.ComponentModel;
using System.IO;
using PKHeX.Core;

namespace PKConverter.Utils
{
	public class PKUtils
	{
        public static void writeDetails(string fileName, PK9 pk9)
        {
            var details = "";
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(pk9))
            {
                try
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(pk9);
                    details += name + "=" + value + "\n";
                }
                catch (Exception e) { }
            }

            File.WriteAllText(fileName, details);
        }

        public static bool checkLegality(string fileName, PKM pkm)
        {
            LegalityAnalysis analysis = new LegalityAnalysis(pkm);

            if(!analysis.Valid)
            {
                File.WriteAllText(fileName, analysis.Report(true));
                var gameString = new GameStrings("en");
                throw new Exception(gameString.specieslist[pkm.Species] + " is not valid !");
            }

            return analysis.Valid;
        }
    }
}

