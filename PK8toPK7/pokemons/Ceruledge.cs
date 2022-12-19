using System;
using PKHeX.Core;

namespace PKConverter
{
	public class Ceruledge
	{
		public Ceruledge()
		{
		}
		public static PK9 bestBuild()
		{
            PK9 newPokemon = baseBuild();

            newPokemon.TeraTypeOriginal = MoveType.Fire;
            newPokemon.SetTeraType(MoveType.Fire);
            newPokemon.SetAbility((int)Ability.WeakArmor);
            newPokemon.Nature = (int)Nature.Adamant;
            newPokemon.SetNature(newPokemon.Nature);

            newPokemon.SetEVs(new int[] { 4, 252, 0, 0, 252, 0 });
            newPokemon.ResetPartyStats();

            newPokemon.HeldItem = 0x0113; // Focus Sash - https://projectpokemon.org/home/docs/gen-4/list-of-items-by-index-number-r23/
            newPokemon.ResetMoves();
            newPokemon.SetMoves(new Moveset((ushort)Move.SwordsDance, (ushort)Move.PsychoCut, (ushort)Move.ShadowSneak, (ushort)Move.BitterBlade));

            finish(newPokemon);

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

            newPokemon.SetEVs(new int[] { 252, 252, 4, 0, 0, 0 });
            newPokemon.ResetPartyStats();

            newPokemon.HeldItem = 0x00EA; // Leftover - https://projectpokemon.org/home/docs/gen-4/list-of-items-by-index-number-r23/
            newPokemon.ResetMoves();
            newPokemon.SetMoves(new Moveset((ushort)Move.SwordsDance, (ushort)Move.PsychoCut, (ushort)Move.ShadowClaw, (ushort)Move.BitterBlade));

            finish(newPokemon);

            return newPokemon;
        }

        public static PK9 teraBuildForCinderace()
		{
            PK9 newPokemon = baseBuild();

            newPokemon.TeraTypeOriginal = MoveType.Fire;
            newPokemon.SetTeraType(MoveType.Ghost);
            newPokemon.SetAbility((int)Ability.FlashFire);
            newPokemon.Nature = (int)Nature.Adamant;
            newPokemon.SetNature(newPokemon.Nature);

            newPokemon.SetEVs(new int[] { 252, 252, 4, 0, 0, 0 });
            newPokemon.ResetPartyStats();
            newPokemon.HeldItem = 0x00EA; // Leftover - https://projectpokemon.org/home/docs/gen-4/list-of-items-by-index-number-r23/
            newPokemon.SetMoves(new Moveset((ushort)Move.SwordsDance, (ushort)Move.PsychoCut, (ushort)Move.ShadowClaw, (ushort)Move.BitterBlade));

            finish(newPokemon);

            return newPokemon;
        }

        private static PK9 baseBuild()
        {

            PK9 newPokemon = new PK9();
            var rnd = Util.Rand;
            var MaxIV = newPokemon.MaxIV;

            newPokemon.Language = (int)LanguageID.English;
            newPokemon.Version = (int)GameVersion.VL;

            newPokemon.Species = (ushort)Species.Ceruledge;
            newPokemon.Ball = (int)Ball.Level;
            newPokemon.MaximizeLevel();
            //newPokemon.SetAbility((int)Ability.WeakArmor);
            //newPokemon.TeraTypeOriginal = MoveType.Fire;
            //newPokemon.SetTeraType(MoveType.Fire);
            //newPokemon.HeldItem = 0x0113; // Focus Sash - https://projectpokemon.org/home/docs/gen-4/list-of-items-by-index-number-r23/

            newPokemon.Met_Location = 20;
            newPokemon.Met_Level = 13;
            newPokemon.Obedience_Level = 13;
            newPokemon.MetDate = new DateTime(2022, 12, 15);

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

            newPokemon.Gender = (int)Gender.Male;
            newPokemon.HeightScalar = 160;
            newPokemon.WeightScalar = 136;
            newPokemon.Scale = 197;
            //newPokemon.Nature = (int)Nature.Adamant;
            //newPokemon.SetNature(newPokemon.Nature);
            newPokemon.SetIVs(new int[] { newPokemon.MaxIV, /*atk*/ rnd.Next(MaxIV + 1), newPokemon.MaxIV, /*speed*/ rnd.Next(MaxIV + 1), newPokemon.MaxIV, newPokemon.MaxIV });
            newPokemon.HT_ATK = true;
            newPokemon.HT_SPE = true;
            //newPokemon.SetEVs(new int[] { 4, 252, 0, 0, 252, 0 });
            //newPokemon.ResetPartyStats();

            //newPokemon.ResetMoves();
            //newPokemon.SetMoves(new Moveset((ushort)Move.SwordsDance, (ushort)Move.CloseCombat, (ushort)Move.ShadowSneak, (ushort)Move.BitterBlade));
            //newPokemon.FixMoves();

            //newPokemon.ClearNickname();
            //newPokemon.EncryptionConstant = 4249466146;
            //newPokemon.SetPIDGender((int)Gender.Male);
            //newPokemon.SetShiny();
            //newPokemon.FixMemories();
            //newPokemon.FixRelearn();
            //newPokemon.RefreshChecksum();

            return newPokemon;
        }

        private static void finish(PK9 newPokemon)
        {
            newPokemon.FixMoves();
            newPokemon.Heal();
            newPokemon.ClearNickname();
            newPokemon.EncryptionConstant = 4249466146;
            newPokemon.SetPIDGender((int)Gender.Male);
            newPokemon.SetShiny();
            newPokemon.FixMemories();
            newPokemon.FixRelearn();
            newPokemon.RefreshChecksum();
        }
    }
}

