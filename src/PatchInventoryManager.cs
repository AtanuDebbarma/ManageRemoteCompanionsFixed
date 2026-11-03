using System.Collections.Generic;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Inventory;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Core;

namespace ManageRemoteCompanionsFix
{
    internal static class PatchInventoryDefaults
    {
        public static Dictionary<CharacterObject, Equipment[]> DefaultCharacterEquipments = new Dictionary<CharacterObject, Equipment[]>();

        public static void SetDefault(CharacterObject character)
        {
            DefaultCharacterEquipments[character] = new Equipment[]
            {
                new Equipment(character.Equipment),
                new Equipment(character.FirstCivilianEquipment)
            };
        }

        public static void ResetCharacter(CharacterObject character)
        {
            Equipment[] saved;
            if (!DefaultCharacterEquipments.TryGetValue(character, out saved))
                return;

            character.Equipment.FillFrom(saved[0], true);
            character.FirstCivilianEquipment.FillFrom(saved[1], true);
        }
    }

    [HarmonyPatch(typeof(InventoryLogic), "InitializeRosters")]
    internal static class PatchInventoryInit
    {
        public static void Prefix(ref TroopRoster rightMemberRoster)
        {
            Settings settings = Settings.Instance;
            if (settings == null || !settings.Enabled || !settings.ApplyInventoryPatch)
                return;
            if (rightMemberRoster == null || !rightMemberRoster.Contains(Hero.MainHero.CharacterObject))
                return;

            TroopRoster newRoster = TroopRoster.CreateDummyTroopRoster();
            newRoster.Add(rightMemberRoster);
            PatchInventoryDefaults.DefaultCharacterEquipments.Clear();

            foreach (Hero hero in Clan.PlayerClan.Heroes)
            {
                if (hero.IsAlive && !hero.IsChild && hero != Hero.MainHero && !newRoster.Contains(hero.CharacterObject))
                {
                    newRoster.AddToCounts(hero.CharacterObject, 1);
                    PatchInventoryDefaults.SetDefault(hero.CharacterObject);
                }
            }

            foreach (Hero hero in Clan.PlayerClan.Companions)
            {
                if (hero.IsAlive && hero.IsPlayerCompanion && !newRoster.Contains(hero.CharacterObject))
                {
                    newRoster.AddToCounts(hero.CharacterObject, 1);
                    PatchInventoryDefaults.SetDefault(hero.CharacterObject);
                }
            }

            rightMemberRoster = newRoster;
        }
    }

    [HarmonyPatch(typeof(InventoryLogic), "ResetLogic")]
    internal static class PatchInventoryReset
    {
        public static void Prefix(InventoryLogic __instance)
        {
            Settings settings = Settings.Instance;
            if (settings == null || !settings.Enabled || !settings.ApplyInventoryPatch)
                return;
            if (__instance == null || __instance.RightMemberRoster == null || __instance.OwnerParty == null)
                return;

            foreach (TroopRosterElement element in __instance.RightMemberRoster.GetTroopRoster())
            {
                CharacterObject character = element.Character;
                if (character != null && character.IsHero && !__instance.OwnerParty.MemberRoster.Contains(character))
                    PatchInventoryDefaults.ResetCharacter(character);
            }
        }
    }
}
