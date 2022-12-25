using System;
using System.IO;
using PKConverter.pokemons;
using PKConverter.Utils;
using PKHeX.Core;

namespace PKConverter.JSOTeam
{
	public class Eevee
	{
		public static void build()
		{
            PK9 eeveePoke = buildWithBall(Ball.Poke);
            PKUtils.checkLegality("/Users/jimmy.somsanith/Downloads/Eevee.pokeball.report.txt", eeveePoke);
            File.WriteAllBytes("/Users/jimmy.somsanith/Downloads/Eevee.pokeball.pk9", eeveePoke.DecryptedPartyData);

            PK9 eeveeLevel = buildWithBall(Ball.Level);
            PKUtils.checkLegality("/Users/jimmy.somsanith/Downloads/Eevee.Level.report.txt", eeveeLevel);
            File.WriteAllBytes("/Users/jimmy.somsanith/Downloads/Eevee.Level.pk9", eeveeLevel.DecryptedPartyData);

            PK9 eeveeLove = buildWithBall(Ball.Love);
            PKUtils.checkLegality("/Users/jimmy.somsanith/Downloads/Eevee.Love.report.txt", eeveeLove);
            File.WriteAllBytes("/Users/jimmy.somsanith/Downloads/Eevee.Love.pk9", eeveeLove.DecryptedPartyData);

            PK9 eeveeDive = buildWithBall(Ball.Dive);
            PKUtils.checkLegality("/Users/jimmy.somsanith/Downloads/Eevee.Dive.report.txt", eeveeDive);
            File.WriteAllBytes("/Users/jimmy.somsanith/Downloads/Eevee.Dive.pk9", eeveeDive.DecryptedPartyData);

            PK9 eeveeFast = buildWithBall(Ball.Fast);
            PKUtils.checkLegality("/Users/jimmy.somsanith/Downloads/Eevee.Fast.report.txt", eeveeFast);
            File.WriteAllBytes("/Users/jimmy.somsanith/Downloads/Eevee.Fast.pk9", eeveeFast.DecryptedPartyData);

            PK9 eeveeFriend = buildWithBall(Ball.Friend);
            PKUtils.checkLegality("/Users/jimmy.somsanith/Downloads/Eevee.Friend.report.txt", eeveeFriend);
            File.WriteAllBytes("/Users/jimmy.somsanith/Downloads/Eevee.Friend.pk9", eeveeFriend.DecryptedPartyData);

            PK9 eeveeDream = buildWithBall(Ball.Dream);
            PKUtils.checkLegality("/Users/jimmy.somsanith/Downloads/Eevee.Dream.report.txt", eeveeDream);
            File.WriteAllBytes("/Users/jimmy.somsanith/Downloads/Eevee.Dream.pk9", eeveeDream.DecryptedPartyData);

            PK9 eeveeLux = buildWithBall(Ball.Luxury);
            PKUtils.checkLegality("/Users/jimmy.somsanith/Downloads/Eevee.Luxury.report.txt", eeveeLux);
            File.WriteAllBytes("/Users/jimmy.somsanith/Downloads/Eevee.Luxury.pk9", eeveeLux.DecryptedPartyData);

            PK9 eeveeMoon = buildWithBall(Ball.Moon);
            PKUtils.checkLegality("/Users/jimmy.somsanith/Downloads/Eevee.Moon.report.txt", eeveeMoon);
            File.WriteAllBytes("/Users/jimmy.somsanith/Downloads/Eevee.Moon.pk9", eeveeMoon.DecryptedPartyData);

            PK9 eeveeHeavy = buildWithBall(Ball.Heavy);
            PKUtils.checkLegality("/Users/jimmy.somsanith/Downloads/Eevee.Heavy.report.txt", eeveeHeavy);
            File.WriteAllBytes("/Users/jimmy.somsanith/Downloads/Eevee.Heavy.pk9", eeveeHeavy.DecryptedPartyData);
        }

        private static PK9 buildWithBall(Ball ball)
        {
            var path = @"/Users/jimmy.somsanith/Downloads/Eevee.pk9";
            var data = File.ReadAllBytes(path);
            PK9 eevee = new PK9(data);
            PKUtils.writeDetails("/Users/jimmy.somsanith/Downloads/eevee.details.txt", eevee);
            PKUtils.checkLegality("/Users/jimmy.somsanith/Downloads/eevee.report.txt", eevee);


            eevee.Gender = (int)Gender.Female;
            eevee.Ball = (int)ball;

            eevee.OT_Name = "Donna";

            eevee.SetRandomIVs(6);
            eevee.FixMoves();

            Base.sanitize(eevee);

            return eevee;
        }

	}
}

