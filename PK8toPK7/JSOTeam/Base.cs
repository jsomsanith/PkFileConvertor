﻿using System;
using PKHeX.Core;

namespace PKConverter.pokemons
{
	public class Base
	{
		public Base() {}

		public static PK9 buildPK9(GameVersion gameVersion = GameVersion.VL)
		{

            PK9 newPokemon = new PK9();

            newPokemon.Language = (int)LanguageID.English;
            newPokemon.Version = (int)gameVersion;

            newPokemon.CurrentHandler = 1;
            newPokemon.OT_Name = "Jimmy";
            newPokemon.OT_Friendship = 255;
            newPokemon.OT_Intensity = 0;
            newPokemon.OT_Memory = 0;
            newPokemon.OT_TextVar = 0;
            newPokemon.OT_Feeling = 0;
            newPokemon.OT_Gender = 0;

            newPokemon.TrainerID7 = 729604;
            newPokemon.TrainerSID7 = 3605;
            newPokemon.DisplayTID = 729604;
            newPokemon.DisplaySID = 3605;

            newPokemon.CurrentFriendship = 255;
            newPokemon.HT_Language = (int)LanguageID.English;
            newPokemon.HT_Name = "Jimmy";

            return newPokemon;
        }

        public static void maxStats(PK9 newPokemon, int[] evs)
        {
            newPokemon.MaximizeLevel();
            newPokemon.SetEVs(evs);
            newPokemon.SetRandomIVs(4);
            Span<int> ivs = stackalloc int[6];
            newPokemon.GetIVs(ivs);
            if (ivs[0] != newPokemon.MaxIV)
            {
                newPokemon.HT_HP = true;
            }
            if (ivs[1] != newPokemon.MaxIV)
            {
                newPokemon.HT_ATK = true;
            }
            if (ivs[2] != newPokemon.MaxIV)
            {
                newPokemon.HT_DEF = true;
            }
            if (ivs[3] != newPokemon.MaxIV)
            {
                newPokemon.HT_SPE = true;
            }
            if (ivs[4] != newPokemon.MaxIV)
            {
                newPokemon.HT_SPA = true;
            }
            if (ivs[5] != newPokemon.MaxIV)
            {
                newPokemon.HT_SPD = true;
            }
        }

        public static void setMoves(PK9 newPokemon, ushort[] moves)
        {
            newPokemon.FixMoves();
            newPokemon.SetMoves(new Moveset(moves[0], moves[1], moves[2], moves[3]));
            TechnicalRecordApplicator.SetRecordFlags(newPokemon, moves);

            var legal = new LegalityAnalysis(newPokemon);
            if (legal.Parsed && !MoveResult.AllValid(legal.Info.Relearn))
            {
                newPokemon.SetRelearnMoves(legal.GetSuggestedRelearnMoves());
            }
            //newPokemon.ResetPartyStats();
            //newPokemon.RefreshChecksum();
        }

        public static void sanitize(PK9 newPokemon, bool rareMark = true)
        {
            newPokemon.Heal();
            newPokemon.ClearNickname();
            newPokemon.EncryptionConstant = 4249466146;
            newPokemon.SetPIDNature(newPokemon.Nature);
            newPokemon.FixMemories();
            newPokemon.FixRelearn();

            newPokemon.SetShinySID(Shiny.AlwaysSquare);
            newPokemon.SetShiny();
            newPokemon.RibbonMarkRare = rareMark;
            newPokemon.RibbonMarkPartner = true;
            newPokemon.RibbonChampionPaldea = true;

            newPokemon.RefreshChecksum();
        }
    }
}

