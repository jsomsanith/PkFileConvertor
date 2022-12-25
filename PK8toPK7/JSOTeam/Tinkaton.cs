using System;
using PKHeX.Core;
using PKConverter.pokemons;

namespace PKConverter
{
	public class Tinkaton
    {
		public static PK9 bestBuild()
		{
            PK9 newPokemon = baseBuild();

            newPokemon.TeraTypeOriginal = MoveType.Steel;
            newPokemon.SetTeraType(MoveType.Steel);
            newPokemon.SetAbility((int)Ability.MoldBreaker);
            newPokemon.Nature = (int)Nature.Impish;
            newPokemon.SetNature(newPokemon.Nature);
            newPokemon.HeldItem = 0x009E; // Sitrus Berry - https://projectpokemon.org/home/docs/gen-4/list-of-items-by-index-number-r23/

            Base.maxStats(newPokemon, new int[] { 244, 0, 252, 0, 0, 12 });
            Base.setMoves(newPokemon, new ushort[] { (ushort)Move.StealthRock, (ushort)Move.KnockOff, (ushort)Move.PlayRough, (ushort)Move.GigatonHammer });
            Base.sanitize(newPokemon);

            return newPokemon;
        }

        public static PK9 teraBuild()
		{
            PK9 newPokemon = baseBuild();

            newPokemon.TeraTypeOriginal = MoveType.Fairy;
            newPokemon.SetTeraType(MoveType.Fairy);
            newPokemon.SetAbility((int)Ability.MoldBreaker);
            newPokemon.Nature = (int)Nature.Adamant;
            newPokemon.SetNature(newPokemon.Nature);
            newPokemon.HeldItem = 0x009E; // Sitrus Berry - https://projectpokemon.org/home/docs/gen-4/list-of-items-by-index-number-r23/

            Base.maxStats(newPokemon, new int[] { 252, 252, 4, 0, 0, 0 });
            Base.setMoves(newPokemon, new ushort[] { (ushort)Move.SwordsDance, (ushort)Move.HelpingHand, (ushort)Move.PlayRough, (ushort)Move.GigatonHammer });
            Base.sanitize(newPokemon);

            return newPokemon;
        }

        private static PK9 baseBuild()
        {

            PK9 newPokemon = Base.buildPK9();

            newPokemon.Species = (ushort)Species.Tinkaton;
            newPokemon.Gender = (int)Gender.Female;
            newPokemon.HeightScalar = 153;
            newPokemon.WeightScalar = 132;
            newPokemon.Scale = 168;
            newPokemon.Ball = (int)Ball.Love;

            newPokemon.Met_Location = 24;
            newPokemon.Met_Level = 26;
            newPokemon.Obedience_Level = 26;
            newPokemon.MetDate = new DateTime(2022, 12, 15);

            return newPokemon;
        }

        
    }
}

