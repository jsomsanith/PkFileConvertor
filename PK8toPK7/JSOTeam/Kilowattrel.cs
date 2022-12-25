using System;
using PKHeX.Core;
using PKConverter.pokemons;

namespace PKConverter
{
	public class Kilowattrel
    {
		public static PK9 bestBuild()
		{
            PK9 newPokemon = baseBuild();

            newPokemon.TeraTypeOriginal = MoveType.Electric;
            newPokemon.SetTeraType(MoveType.Electric);
            newPokemon.SetAbility((int)Ability.VoltAbsorb);
            newPokemon.Nature = (int)Nature.Modest;
            newPokemon.SetNature(newPokemon.Nature);
            newPokemon.HeldItem = 0x0113; // Focus Sash - https://projectpokemon.org/home/docs/gen-4/list-of-items-by-index-number-r23/

            Base.maxStats(newPokemon, new int[] { 4, 0, 0, 252, 252, 0 });
            Base.setMoves(newPokemon, new ushort[] { (ushort)Move.VoltSwitch, (ushort)Move.Discharge, (ushort)Move.Tailwind, (ushort)Move.AirSlash });
            Base.sanitize(newPokemon);

            return newPokemon;
        }

        private static PK9 baseBuild()
        {

            PK9 newPokemon = Base.buildPK9();

            newPokemon.Species = (ushort)Species.Kilowattrel;
            newPokemon.Gender = (int)Gender.Male;
            newPokemon.HeightScalar = 104;
            newPokemon.WeightScalar = 144;
            newPokemon.Scale = 88;
            newPokemon.Ball = (int)Ball.Fast;

            newPokemon.Met_Location = 44;
            newPokemon.Met_Level = 47;
            newPokemon.Obedience_Level = 47;
            newPokemon.MetDate = new DateTime(2022, 12, 15);

            return newPokemon;
        }
    }
}

