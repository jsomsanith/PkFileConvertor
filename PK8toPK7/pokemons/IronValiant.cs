using System;
using PKHeX.Core;
using PKConverter.pokemons;

namespace PKConverter
{
	public class IronValiant
    {
		public IronValiant()
		{
		}
        public static PK9 bestBuild()
        {
            PK9 newPokemon = baseBuild();

            newPokemon.TeraTypeOriginal = MoveType.Fairy;
            newPokemon.SetTeraType(MoveType.Fairy);
            newPokemon.SetAbility((int)Ability.QuarkDrive);
            newPokemon.Nature = (int)Nature.Jolly;
            newPokemon.SetNature(newPokemon.Nature);

            newPokemon.SetEVs(new int[] { 0, 252, 0, 252, 0, 4 });

            newPokemon.HeldItem = 0x0758; // Booster energy
            newPokemon.SetMoves(new Moveset((ushort)Move.SwordsDance, (ushort)Move.PsychoCut, (ushort)Move.CloseCombat, (ushort)Move.SpiritBreak));

            Base.sanitize(newPokemon);

            return newPokemon;
        }

        public static PK9 teraBuild()
		{
            PK9 newPokemon = baseBuild();

            newPokemon.TeraTypeOriginal = MoveType.Fighting;
            newPokemon.SetTeraType(MoveType.Fighting);
            newPokemon.SetAbility((int)Ability.QuarkDrive);
            newPokemon.Nature = (int)Nature.Adamant;
            newPokemon.SetNature(newPokemon.Nature);

            newPokemon.SetEVs(new int[] { 252, 252, 0, 0, 0, 4 });

            newPokemon.HeldItem = 0x0758; // Booster energy
            newPokemon.SetMoves(new Moveset((ushort)Move.SwordsDance, (ushort)Move.Liquidation, (ushort)Move.SpiritBreak, (ushort)Move.DrainPunch));

            Base.sanitize(newPokemon);

            return newPokemon;
        }

        public static PK9 teraBuildForSupport()
		{
            PK9 newPokemon = baseBuild();

            newPokemon.TeraTypeOriginal = MoveType.Fairy;
            newPokemon.SetTeraType(MoveType.Fairy);
            newPokemon.SetAbility((int)Ability.QuarkDrive);
            newPokemon.Nature = (int)Nature.Timid;
            newPokemon.SetNature(newPokemon.Nature);

            newPokemon.SetEVs(new int[] { 252, 0, 0, 252, 6, 0 });

            newPokemon.HeldItem = 0x010D; // Light Clay - https://projectpokemon.org/home/docs/gen-4/list-of-items-by-index-number-r23/
            newPokemon.SetMoves(new Moveset((ushort)Move.Reflect, (ushort)Move.LightScreen, (ushort)Move.Taunt, (ushort)Move.Moonblast));

            Base.sanitize(newPokemon);

            return newPokemon;
        }

        private static PK9 baseBuild()
        {

            PK9 newPokemon = Base.buildPK9();

            newPokemon.Species = (ushort)Species.IronValiant;
            newPokemon.Gender = (int)Gender.Genderless;
            newPokemon.HeightScalar = 61;
            newPokemon.WeightScalar = 62;
            newPokemon.Scale = 135;
            newPokemon.Ball = (int)Ball.Premier;

            newPokemon.Met_Location = 124;
            newPokemon.Met_Level = 59;
            newPokemon.Obedience_Level = 59;
            newPokemon.MetDate = new DateTime(2022, 12, 16);

            return newPokemon;
        }

        
    }
}

