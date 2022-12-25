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
            //PKUtils.writeDetails("/Users/jimmy.somsanith/Downloads/team/Ceruledge.best.details.txt", ceruledge);
            PKUtils.checkLegality("/Users/jimmy.somsanith/Downloads/team/Ceruledge.best.report.txt", ceruledge);
            File.WriteAllBytes("/Users/jimmy.somsanith/Downloads/team/Ceruledge.best.pk9", ceruledge.DecryptedPartyData);

            PK9 ceruledgeTera = Ceruledge.teraBuild();
            //PKUtils.writeDetails("/Users/jimmy.somsanith/Downloads/team/Ceruledge.tera.details.txt", ceruledgeTera);
            PKUtils.checkLegality("/Users/jimmy.somsanith/Downloads/team/Ceruledge.tera.report.txt", ceruledgeTera);
            File.WriteAllBytes("/Users/jimmy.somsanith/Downloads/team/Ceruledge.tera.pk9", ceruledgeTera.DecryptedPartyData);

            PK9 ceruledgeTera2 = Ceruledge.teraBuildForCinderace();
            //PKUtils.writeDetails("/Users/jimmy.somsanith/Downloads/team/Ceruledge.tera2.details.txt", ceruledgeTera2);
            PKUtils.checkLegality("/Users/jimmy.somsanith/Downloads/team/Ceruledge.tera2.report.txt", ceruledgeTera2);
            File.WriteAllBytes("/Users/jimmy.somsanith/Downloads/team/Ceruledge.tera2.pk9", ceruledgeTera2.DecryptedPartyData);

            PK9 ironValiant = IronValiant.bestBuild();
            //PKUtils.writeDetails("/Users/jimmy.somsanith/Downloads/team/IronValiant.best.details.txt", ironValiant);
            PKUtils.checkLegality("/Users/jimmy.somsanith/Downloads/team/IronValiant.best.report.txt", ironValiant);
            File.WriteAllBytes("/Users/jimmy.somsanith/Downloads/team/IronValiant.best.pk9", ironValiant.DecryptedPartyData);

            PK9 ironValianTera = IronValiant.teraBuild();
            //PKUtils.writeDetails("/Users/jimmy.somsanith/Downloads/team/IronValiant.tera.details.txt", ironValianTera);
            PKUtils.checkLegality("/Users/jimmy.somsanith/Downloads/team/IronValiant.tera.report.txt", ironValianTera);
            File.WriteAllBytes("/Users/jimmy.somsanith/Downloads/team/IronValiant.tera.pk9", ironValianTera.DecryptedPartyData);

            PK9 ironValiantTeraSupport = IronValiant.teraBuildForSupport();
            //PKUtils.writeDetails("/Users/jimmy.somsanith/Downloads/team/IronValiant.teraSupport.details.txt", ironValiantTeraSupport);
            PKUtils.checkLegality("/Users/jimmy.somsanith/Downloads/team/IronValiant.teraSupport.report.txt", ironValiantTeraSupport);
            File.WriteAllBytes("/Users/jimmy.somsanith/Downloads/team/IronValiant.teraSupport.pk9", ironValiantTeraSupport.DecryptedPartyData);

            PK9 roaringMoon = RoaringMoon.bestBuild();
            //PKUtils.writeDetails("/Users/jimmy.somsanith/Downloads/team/RoaringMoon.best.details.txt", ironValiant);
            PKUtils.checkLegality("/Users/jimmy.somsanith/Downloads/team/RoaringMoon.best.report.txt", roaringMoon);
            File.WriteAllBytes("/Users/jimmy.somsanith/Downloads/team/RoaringMoon.best.pk9", roaringMoon.DecryptedPartyData);

            PK9 tinkaton = Tinkaton.bestBuild();
            //PKUtils.writeDetails("/Users/jimmy.somsanith/Downloads/team/Tinkaton.best.details.txt", tinkaton);
            PKUtils.checkLegality("/Users/jimmy.somsanith/Downloads/team/Tinkaton.best.report.txt", tinkaton);
            File.WriteAllBytes("/Users/jimmy.somsanith/Downloads/team/Tinkaton.best.pk9", tinkaton.DecryptedPartyData);

            PK9 tinkatonTera = Tinkaton.bestBuild();
            //PKUtils.writeDetails("/Users/jimmy.somsanith/Downloads/team/Tinkaton.tera.details.txt", tinkatonTera);
            PKUtils.checkLegality("/Users/jimmy.somsanith/Downloads/team/Tinkaton.tera.report.txt", tinkatonTera);
            File.WriteAllBytes("/Users/jimmy.somsanith/Downloads/team/Tinkaton.tera.pk9", tinkatonTera.DecryptedPartyData);

            PK9 kilowattrel = Kilowattrel.bestBuild();
            //PKUtils.writeDetails("/Users/jimmy.somsanith/Downloads/team/Kilowattrel.best.details.txt", kilowattrel);
            PKUtils.checkLegality("/Users/jimmy.somsanith/Downloads/team/Kilowattrel.best.report.txt", kilowattrel);
            File.WriteAllBytes("/Users/jimmy.somsanith/Downloads/team/Kilowattrel.best.pk9", kilowattrel.DecryptedPartyData);
        }
	}
}

