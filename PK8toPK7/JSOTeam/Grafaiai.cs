using System;
using PKHeX.Core;
using PKConverter.pokemons;

namespace PKConverter
{
	public class Grafaiai
    {
		public static PK9 bestBuild()
		{
            PK9 newPokemon = baseBuild();

            newPokemon.TeraTypeOriginal = MoveType.Normal;
            newPokemon.SetTeraType(MoveType.Normal);
            newPokemon.SetAbility((int)Ability.Unburden);
            newPokemon.Nature = (int)Nature.Jolly;
            newPokemon.SetNature(newPokemon.Nature);
            newPokemon.HeldItem = 0x0234; // Normal Gem

            Base.maxStats(newPokemon, new int[] { 0, 252, 0, 252, 0, 4 });
            Base.setMoves(newPokemon, new ushort[] { (ushort)Move.SwordsDance, (ushort)Move.LowKick, (ushort)Move.TeraBlast, (ushort)Move.GunkShot});
            Base.sanitize(newPokemon, false /*no rare mark*/);

            return newPokemon;
        }

        private static PK9 baseBuild()
        {

            PK9 newPokemon = Base.buildPK9();

            newPokemon.Species = (ushort)Species.Grafaiai;
            newPokemon.Gender = (int)Gender.Male;
            newPokemon.HeightScalar = 160;
            newPokemon.WeightScalar = 148;
            newPokemon.Scale = 123;
            newPokemon.Ball = (int)Ball.Heavy;

            newPokemon.Met_Location = 30;
            newPokemon.Met_Level = 24;
            newPokemon.Obedience_Level = 24;
            newPokemon.MetDate = new DateTime(2022, 12, 15);

            return newPokemon;
        }
    }
}

