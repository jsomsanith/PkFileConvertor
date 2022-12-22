using System;
using System.IO;
using PKHeX.Core;
using PKConverter.Utils;

namespace PKConverter.JSOTeam
{
	public class JSOTeam
	{
		public static void buildTeamPK9()
		{
            LocalizeUtil.InitializeStrings("en");

            PK9 ceruledge = Ceruledge.bestBuild();
            //PKUtils.writeDetails("/Users/jimmy.somsanith/Downloads/Ceruledge.best.details.txt", ceruledge);
            PKUtils.checkLegality("/Users/jimmy.somsanith/Downloads/Ceruledge.best.report.txt", ceruledge);
            File.WriteAllBytes("/Users/jimmy.somsanith/Downloads/Ceruledge.best.pk9", ceruledge.DecryptedPartyData);

            PK9 ceruledgeTera = Ceruledge.teraBuild();
            //PKUtils.writeDetails("/Users/jimmy.somsanith/Downloads/Ceruledge.tera.details.txt", ceruledgeTera);
            PKUtils.checkLegality("/Users/jimmy.somsanith/Downloads/Ceruledge.tera.report.txt", ceruledgeTera);
            File.WriteAllBytes("/Users/jimmy.somsanith/Downloads/Ceruledge.tera.pk9", ceruledgeTera.DecryptedPartyData);

            PK9 ceruledgeTera2 = Ceruledge.teraBuildForCinderace();
            //PKUtils.writeDetails("/Users/jimmy.somsanith/Downloads/Ceruledge.tera2.details.txt", ceruledgeTera2);
            PKUtils.checkLegality("/Users/jimmy.somsanith/Downloads/Ceruledge.tera2.report.txt", ceruledgeTera2);
            File.WriteAllBytes("/Users/jimmy.somsanith/Downloads/Ceruledge.tera2.pk9", ceruledgeTera2.DecryptedPartyData);

            PK9 ironValiant = IronValiant.bestBuild();
            //PKUtils.writeDetails("/Users/jimmy.somsanith/Downloads/IronValiant.best.details.txt", ironValiant);
            PKUtils.checkLegality("/Users/jimmy.somsanith/Downloads/IronValiant.best.report.txt", ironValiant);
            File.WriteAllBytes("/Users/jimmy.somsanith/Downloads/IronValiant.best.pk9", ironValiant.DecryptedPartyData);

            PK9 ironValianTera = IronValiant.teraBuild();
            //PKUtils.writeDetails("/Users/jimmy.somsanith/Downloads/IronValiant.tera.details.txt", ironValianTera);
            PKUtils.checkLegality("/Users/jimmy.somsanith/Downloads/IronValiant.tera.report.txt", ironValianTera);
            File.WriteAllBytes("/Users/jimmy.somsanith/Downloads/IronValiant.tera.pk9", ironValianTera.DecryptedPartyData);

            PK9 ironValiantTeraSupport = IronValiant.teraBuildForSupport();
            PKUtils.writeDetails("/Users/jimmy.somsanith/Downloads/IronValiant.teraSupport.details.txt", ironValiantTeraSupport);
            PKUtils.checkLegality("/Users/jimmy.somsanith/Downloads/IronValiant.teraSupport.report.txt", ironValiantTeraSupport);
            File.WriteAllBytes("/Users/jimmy.somsanith/Downloads/IronValiant.teraSupport.pk9", ironValiantTeraSupport.DecryptedPartyData);
        }
	}
}

