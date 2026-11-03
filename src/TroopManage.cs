using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement;

namespace ManageRemoteCompanionsFix
{
    // Shared rules for which clan-party rows can open remote troop management.
    internal static class TroopManage
    {
        public static bool CanManage(ClanPartyItemVM partyItem)
        {
            Settings settings = Settings.Instance;
            if (settings == null || !settings.Enabled || !settings.ManageTroops)
                return false;
            if (partyItem == null || partyItem.Party == null)
                return false;

            MobileParty mobileParty = partyItem.Party.MobileParty;
            if (mobileParty == null || !mobileParty.IsActive)
                return false;

            if (mobileParty.IsGarrison)
                return settings.ManageGarrisons;
            if (mobileParty.IsCaravan)
                return settings.ManageCaravans;
            if (mobileParty.IsMainParty)
                return false;
            if (mobileParty.LeaderHero == Hero.MainHero)
                return false;

            return settings.ManageParties;
        }
    }
}
