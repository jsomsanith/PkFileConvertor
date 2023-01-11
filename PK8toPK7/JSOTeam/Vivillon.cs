using System;
using PKHeX.Core;
using PKConverter.pokemons;
using System.IO;

namespace PKConverter
{
	public class Vivillon
    {
		public static PK9 bestBuild()
		{
            PK9 newPokemon = baseBuild();

            newPokemon.TeraTypeOriginal = MoveType.Flying;
            newPokemon.SetTeraType(MoveType.Flying);
            newPokemon.SetAbility((int)Ability.CompoundEyes);
            newPokemon.Nature = (int)Nature.Modest;
            newPokemon.SetNature(newPokemon.Nature);
            newPokemon.HeldItem = 0x00EA; // Leftovers - https://projectpokemon.org/home/docs/gen-4/list-of-items-by-index-number-r23/

            Base.maxStats(newPokemon, new int[] { 4, 0, 0, 252, 252, 0 });
            Base.setMoves(newPokemon, new ushort[] { (ushort)Move.SleepPowder, (ushort)Move.QuiverDance, (ushort)Move.BugBuzz, (ushort)Move.Hurricane });
            Base.sanitize(newPokemon, false /*no rare mark*/);

            return newPokemon;
        }

        private static PK9 baseBuild()
        {

            PK9 newPokemon = Base.buildPK9();

            newPokemon.Species = (ushort)Species.Vivillon;
            newPokemon.Form = 18;
            newPokemon.Gender = (int)Gender.Female;
            newPokemon.HeightScalar = 160;
            newPokemon.WeightScalar = 58;
            newPokemon.Scale = 164;
            newPokemon.Ball = (int)Ball.Love;

            newPokemon.Met_Location = 44;
            newPokemon.Met_Level = 44;
            newPokemon.Obedience_Level = 44;
            newPokemon.MetDate = new DateTime(2022, 12, 15);

            return newPokemon;
        }
    }
}

