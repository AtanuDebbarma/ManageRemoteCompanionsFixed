using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;

namespace ManageRemoteCompanionsFix
{
    public sealed class Settings : AttributeGlobalSettings<Settings>
    {
        public override string DisplayName
        {
            get { return "Manage Remote Companions Fix"; }
        }

        public override string FolderName
        {
            get { return "ManageRemoteCompanionsFix"; }
        }

        public override string Id
        {
            get { return "ManageRemoteCompanionsFix_v1.0.0"; }
        }

        public override string FormatType
        {
            get { return "json2"; }
        }

        [SettingPropertyBool("Enabled", IsToggle = true, Order = 1, RequireRestart = false, HintText = "Toggle this mod on or off.")]
        [SettingPropertyGroup("Enabled", GroupOrder = 0)]
        public bool Enabled { get; set; }

        [SettingPropertyBool("Character Upgrades", Order = 2, RequireRestart = false, HintText = "Allows allocating perks, attribute points and focus points for remote companions and adult family in your clan.")]
        [SettingPropertyGroup("Enabled")]
        public bool CharacterUpgrades { get; set; }

        [SettingPropertyBool("Manage Equipment", Order = 3, RequireRestart = false, HintText = "Adds your remote clan companions and adult family members to the Inventory screen so their equipment can be managed.")]
        [SettingPropertyGroup("Enabled")]
        public bool ApplyInventoryPatch { get; set; }

        [SettingPropertyBool("Enable Manage Troops", IsToggle = true, Order = 4, RequireRestart = false, HintText = "Show a Manage Troops button on the Clan Parties right panel for companion parties, caravans, and garrisons.")]
        [SettingPropertyGroup("Enabled/Manage Troops", GroupOrder = 1)]
        public bool ManageTroops { get; set; }

        [SettingPropertyBool("Manage Troops of Companion Parties", Order = 5, RequireRestart = false, HintText = "Enables troop management for your clan parties.")]
        [SettingPropertyGroup("Enabled/Manage Troops")]
        public bool ManageParties { get; set; }

        [SettingPropertyBool("Manage Troops of Companion Caravans", Order = 6, RequireRestart = false, HintText = "Enables troop management for your clan caravans.")]
        [SettingPropertyGroup("Enabled/Manage Troops")]
        public bool ManageCaravans { get; set; }

        [SettingPropertyBool("Manage Settlement Garrisons", Order = 7, RequireRestart = false, HintText = "Enables troop management for your clan settlement garrisons.")]
        [SettingPropertyGroup("Enabled/Manage Troops")]
        public bool ManageGarrisons { get; set; }

        public Settings()
        {
            Enabled = true;
            CharacterUpgrades = true;
            ApplyInventoryPatch = true;
            ManageTroops = true;
            ManageParties = true;
            ManageCaravans = true;
            ManageGarrisons = false;
        }
    }
}
