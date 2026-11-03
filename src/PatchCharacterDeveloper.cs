using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.ViewModelCollection.CharacterDeveloper;

namespace ManageRemoteCompanionsFix
{
    [HarmonyPatch(typeof(SkillVM), "IsPerkAvailable")]
    internal static class PatchIsPerkAvailable
    {
        public static void Postfix(SkillVM __instance, PerkObject perk, ref bool __result)
        {
            Settings settings = Settings.Instance;
            if (settings != null && settings.Enabled && settings.CharacterUpgrades)
                __result = perk.RequiredSkillValue <= __instance.Level;
        }
    }

    [HarmonyPatch(typeof(CharacterDeveloperHeroItemVM), "CanAddFocusToSkillWithFocusAmount")]
    internal static class PatchSkillFocus
    {
        public static void Postfix(CharacterDeveloperHeroItemVM __instance, int currentFocusAmount, ref bool __result)
        {
            Settings settings = Settings.Instance;
            if (settings == null || !settings.Enabled || !settings.CharacterUpgrades)
                return;

            int maxFocus = 5;
            if (Campaign.Current != null && Campaign.Current.Models != null && Campaign.Current.Models.CharacterDevelopmentModel != null)
                maxFocus = Campaign.Current.Models.CharacterDevelopmentModel.MaxFocusPerSkill;

            __result = currentFocusAmount < maxFocus && __instance.UnspentCharacterPoints > 0;
        }
    }

    [HarmonyPatch(typeof(CharacterAttributeItemVM), "RefreshWithCurrentValues")]
    internal static class PatchAttributePoints
    {
        public static void Postfix(CharacterAttributeItemVM __instance)
        {
            Settings settings = Settings.Instance;
            if (settings == null || !settings.Enabled || !settings.CharacterUpgrades)
                return;

            int maxAttribute = 10;
            if (Campaign.Current != null && Campaign.Current.Models != null && Campaign.Current.Models.CharacterDevelopmentModel != null)
                maxAttribute = Campaign.Current.Models.CharacterDevelopmentModel.MaxAttribute;

            __instance.CanAddPoint = __instance.AttributeValue < maxAttribute && __instance.UnspentAttributePoints > 0;
        }
    }
}
