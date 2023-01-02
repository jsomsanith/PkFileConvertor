using System;
using PKHeX.Core;
using PKConverter.pokemons;

namespace PKConverter
{
	public class Ceruledge
	{
		public static PK9 bestBuild()
		{
            PK9 newPokemon = baseBuild();

            newPokemon.TeraTypeOriginal = MoveType.Fire;
            newPokemon.SetTeraType(MoveType.Fire);
            newPokemon.SetAbility((int)Ability.WeakArmor);
            newPokemon.Nature = (int)Nature.Adamant;
            newPokemon.SetNature(newPokemon.Nature);
            newPokemon.HeldItem = 0x0113; // Focus Sash - https://projectpokemon.org/home/docs/gen-4/list-of-items-by-index-number-r23/

            Base.maxStats(newPokemon, new int[] { 4, 252, 0, 0, 252, 0 });
            Base.setMoves(newPokemon, new ushort[] { (ushort)Move.SwordsDance, (ushort)Move.CloseCombat, (ushort)Move.ShadowSneak, (ushort)Move.BitterBlade });
            Base.sanitize(newPokemon);

            return newPokemon;
        }

        public static PK9 teraBuild()
		{
            PK9 newPokemon = baseBuild();

            newPokemon.TeraTypeOriginal = MoveType.Fire;
            newPokemon.SetTeraType(MoveType.Fire);
            newPokemon.SetAbility((int)Ability.FlashFire);
            newPokemon.Nature = (int)Nature.Adamant;
            newPokemon.SetNature(newPokemon.Nature);
            newPokemon.HeldItem = 0x00EA; // Leftover - https://projectpokemon.org/home/docs/gen-4/list-of-items-by-index-number-r23/

            Base.maxStats(newPokemon, new int[] { 252, 252, 4, 0, 0, 0 });
            Base.setMoves(newPokemon, new ushort[] { (ushort)Move.SwordsDance, (ushort)Move.CloseCombat, (ushort)Move.PhantomForce, (ushort)Move.BitterBlade });
            Base.sanitize(newPokemon);

            return newPokemon;
        }

        private static PK9 baseBuild()
        {

            PK9 newPokemon = Base.buildPK9();

            newPokemon.Species = (ushort)Species.Ceruledge;
            newPokemon.Gender = (int)Gender.Male;
            newPokemon.HeightScalar = 160;
            newPokemon.WeightScalar = 136;
            newPokemon.Scale = 197;
            newPokemon.Ball = (int)Ball.Level;

            newPokemon.Met_Location = 20;
            newPokemon.Met_Level = 13;
            newPokemon.Obedience_Level = 13;
            newPokemon.MetDate = new DateTime(2022, 12, 15);

            return newPokemon;
        }

        
    }
}

