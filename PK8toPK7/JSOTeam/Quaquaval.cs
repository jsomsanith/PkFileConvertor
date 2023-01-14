using System;
using System.IO;
using PKHeX.Core;
using PKConverter.pokemons;

namespace PKConverter
{
	public class Quaquaval
    {
		public static PK9 bestBuild()
		{
            PK9 newPokemon = baseBuild();

            newPokemon.TeraTypeOriginal = MoveType.Water;
            newPokemon.SetTeraType(MoveType.Water);
            newPokemon.SetAbility((int)Ability.Moxie);
            newPokemon.Nature = (int)Nature.Jolly;
            newPokemon.SetNature(newPokemon.Nature);
            newPokemon.HeldItem = 0x0113; // Focus Sash - https://projectpokemon.org/home/docs/gen-4/list-of-items-by-index-number-r23/

            Base.maxStats(newPokemon, new int[] { 4, 252, 0, 252, 0, 0 });
            Base.setMoves(newPokemon, new ushort[] { (ushort)Move.SwordsDance, (ushort)Move.CloseCombat, (ushort)Move.IceSpinner, (ushort)Move.AquaStep });
            Base.sanitize(newPokemon, false /* no rare mark */);

            return newPokemon;
        }

        private static PK9 baseBuild()
        {

            PK9 newPokemon = Base.buildPK9();

            newPokemon.Species = (ushort)Species.Quaquaval;
            newPokemon.Gender = (int)Gender.Female;
            newPokemon.HeightScalar = 170;
            newPokemon.WeightScalar = 186;
            newPokemon.Scale = 53;
            newPokemon.Ball = (int)Ball.Poke;

            newPokemon.Met_Location = 96;
            newPokemon.Met_Level = 1;
            newPokemon.Obedience_Level = 1;
            newPokemon.MetDate = new DateTime(2022, 12, 14);
            newPokemon.Egg_Location = 30023;
            newPokemon.EggMetDate = newPokemon.MetDate;

            return newPokemon;
        }

        
    }
}

