using System;
using System.IO;
using PKHeX.Core;
using PKConverter.pokemons;

namespace PKConverter
{
	public class Meowscarada
    {
		public static PK9 bestBuild()
		{
            PK9 newPokemon = baseBuild();

            newPokemon.TeraTypeOriginal = MoveType.Grass;
            newPokemon.SetTeraType(MoveType.Dark);
            newPokemon.SetAbility((int)Ability.Protean);
            newPokemon.Nature = (int)Nature.Jolly;
            newPokemon.SetNature(newPokemon.Nature);
            newPokemon.HeldItem = 0x010E; // Life Orb - https://projectpokemon.org/home/docs/gen-4/list-of-items-by-index-number-r23/

            Base.maxStats(newPokemon, new int[] { 0, 252, 0, 252, 0, 4 });
            Base.setMoves(newPokemon, new ushort[] { (ushort)Move.KnockOff, (ushort)Move.SuckerPunch, (ushort)Move.PlayRough, (ushort)Move.FlowerTrick });
            Base.sanitize(newPokemon, false /* no rare mark */);

            return newPokemon;
        }

        public static PK9 teraBuild()
        {
            PK9 newPokemon = baseBuild();

            newPokemon.TeraTypeOriginal = MoveType.Grass;
            newPokemon.SetTeraType(MoveType.Grass);
            newPokemon.SetAbility((int)Ability.Overgrow);
            newPokemon.Nature = (int)Nature.Rash;
            newPokemon.SetNature(newPokemon.Nature);
            newPokemon.HeldItem = 0x374; // Grassy seed

            Base.maxStats(newPokemon, new int[] { 4, 252, 0, 0, 252, 0 });
            Base.setMoves(newPokemon, new ushort[] { (ushort)Move.GrassyTerrain, (ushort)Move.GigaDrain, (ushort)Move.LeafStorm, (ushort)Move.FlowerTrick });
            Base.sanitize(newPokemon, false /* no rare mark */);

            return newPokemon;
        }

        private static PK9 baseBuild()
        {

            PK9 newPokemon = Base.buildPK9();

            newPokemon.Species = (ushort)Species.Meowscarada;
            newPokemon.Gender = (int)Gender.Female;
            newPokemon.HeightScalar = 174;
            newPokemon.WeightScalar = 76;
            newPokemon.Scale = 169;
            newPokemon.Ball = (int)Ball.Poke;

            newPokemon.Met_Location = 96;
            newPokemon.Met_Level = 1;
            newPokemon.Obedience_Level = 1;
            newPokemon.MetDate = new DateTime(2022, 11, 18);
            newPokemon.Egg_Location = 30023;
            newPokemon.EggMetDate = newPokemon.MetDate;

            return newPokemon;
        }

        
    }
}

