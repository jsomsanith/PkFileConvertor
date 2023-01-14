using System;
using System.IO;
using PKHeX.Core;
using PKConverter.pokemons;

namespace PKConverter
{
	public class Skeledirge
    {
		public static PK9 bestBuild()
		{
            PK9 newPokemon = baseBuild();

            newPokemon.TeraTypeOriginal = MoveType.Fire;
            newPokemon.SetTeraType(MoveType.Fire);
            newPokemon.SetAbility((int)Ability.Unaware);
            newPokemon.Nature = (int)Nature.Modest;
            newPokemon.SetNature(newPokemon.Nature);
            newPokemon.HeldItem = 0x280; // Assault vest

            Base.maxStats(newPokemon, new int[] { 220, 0, 0, 0, 252, 36 });
            Base.setMoves(newPokemon, new ushort[] { (ushort)Move.ShadowBall, (ushort)Move.EarthPower, (ushort)Move.TorchSong, (ushort)Move.Overheat });
            Base.sanitize(newPokemon, false /* no rare mark */);

            return newPokemon;
        }

        public static PK9 teraBuild()
        {
            PK9 newPokemon = baseBuild();

            newPokemon.TeraTypeOriginal = MoveType.Fire;
            newPokemon.SetTeraType(MoveType.Fire);
            newPokemon.SetAbility((int)Ability.Unaware);
            newPokemon.Nature = (int)Nature.Modest;
            newPokemon.SetNature(newPokemon.Nature);
            newPokemon.HeldItem = 0x45E; // Throat spray
            Base.maxStats(newPokemon, new int[] { 252, 0, 0, 0, 252, 4 });
            Base.setMoves(newPokemon, new ushort[] { (ushort)Move.Yawn, (ushort)Move.SlackOff, (ushort)Move.ShadowBall, (ushort)Move.TorchSong });
            Base.sanitize(newPokemon, false /* no rare mark */);

            return newPokemon;
        }

        private static PK9 baseBuild()
        {

            PK9 newPokemon = Base.buildPK9();

            newPokemon.Species = (ushort)Species.Skeledirge;
            newPokemon.Gender = (int)Gender.Male;
            newPokemon.HeightScalar = 88;
            newPokemon.WeightScalar = 104;
            newPokemon.Scale = 105;
            newPokemon.Ball = (int)Ball.Poke;

            newPokemon.Met_Location = 96;
            newPokemon.Met_Level = 1;
            newPokemon.Obedience_Level = 1;
            newPokemon.MetDate = new DateTime(2022, 12, 15);
            newPokemon.Egg_Location = 30023;
            newPokemon.EggMetDate = newPokemon.MetDate;

            return newPokemon;
        }

        
    }
}

