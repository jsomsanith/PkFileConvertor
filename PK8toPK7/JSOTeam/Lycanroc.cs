using System;
using System.IO;
using PKHeX.Core;
using PKConverter.pokemons;
using PKConverter.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PKConverter
{
	public class Lycanroc
	{
		public static PK9 bestBuild()
		{
            PK9 newPokemon = baseBuild();

            newPokemon.TeraTypeOriginal = MoveType.Rock;
            newPokemon.SetTeraType(MoveType.Rock);
            newPokemon.SetAbility((int)Ability.ToughClaws);
            newPokemon.Nature = (int)Nature.Jolly;
            newPokemon.SetNature(newPokemon.Nature);
            newPokemon.HeldItem = 0x0113; // Focus Sash - https://projectpokemon.org/home/docs/gen-4/list-of-items-by-index-number-r23/

            Base.maxStats(newPokemon, new int[] { 0, 252, 0, 252, 0, 4 });
            Base.setMoves(newPokemon, new ushort[] { (ushort)Move.StealthRock, (ushort)Move.CloseCombat, (ushort)Move.Accelerock, (ushort)Move.StoneEdge });
            Base.sanitize(newPokemon);

            return newPokemon;
        }

        private static PK9 baseBuild()
        {
            PK9 newPokemon = Base.buildPK9();

            newPokemon.Species = (ushort)Species.Lycanroc;
            newPokemon.Form = 2; // Dusk 
            newPokemon.Gender = (int)Gender.Male;
            newPokemon.HeightScalar = 64;
            newPokemon.WeightScalar = 173;
            newPokemon.Scale = 102;
            newPokemon.Ball = (int)Ball.Moon;

            newPokemon.Met_Location = 46;
            newPokemon.Met_Level = 50;
            newPokemon.Obedience_Level = 50;
            newPokemon.MetDate = new DateTime(2022, 12, 15);

            return newPokemon;
        }

        
    }
}

