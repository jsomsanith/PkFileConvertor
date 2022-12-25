using System;
using PKHeX.Core;
using PKConverter.pokemons;

namespace PKConverter
{
	public class RoaringMoon
    {
        public static PK9 bestBuild()
        {
            PK9 newPokemon = baseBuild();

            newPokemon.TeraTypeOriginal = MoveType.Dragon;
            newPokemon.SetTeraType(MoveType.Steel);
            newPokemon.SetAbility((int)Ability.Protosynthesis);
            newPokemon.Nature = (int)Nature.Jolly;
            newPokemon.SetNature(newPokemon.Nature);
            newPokemon.HeldItem = 0x0758; // Booster energy

            Base.maxStats(newPokemon, new int[] { 0, 252, 0, 252, 0, 4 });
            Base.setMoves(newPokemon, new ushort[] { (ushort)Move.DragonDance, (ushort)Move.IronHead, (ushort)Move.Acrobatics, (ushort)Move.Crunch });
            Base.sanitize(newPokemon);

            return newPokemon;
        }

        private static PK9 baseBuild()
        {

            PK9 newPokemon = Base.buildPK9(GameVersion.SL);

            newPokemon.Species = (ushort)Species.RoaringMoon;
            newPokemon.Gender = (int)Gender.Genderless;
            newPokemon.HeightScalar = 203;
            newPokemon.WeightScalar = 101;
            newPokemon.Scale = 149;
            newPokemon.Ball = (int)Ball.Moon;

            newPokemon.Met_Location = 124;
            newPokemon.Met_Level = 59;
            newPokemon.Obedience_Level = 59;
            newPokemon.MetDate = new DateTime(2022, 12, 16);

            return newPokemon;
        }

        
    }
}

