using Bannerlord.UIExtenderEx.Attributes;
using Bannerlord.UIExtenderEx.ViewModels;
using Helpers;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement;
using TaleWorlds.Core.ViewModelCollection.Information;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace ManageRemoteCompanionsFix
{
    // Adds Manage Troops command/properties to the vanilla ClanPartyItemVM used by Clan > Parties.
    [ViewModelMixin("RefreshValues")]
    internal sealed class ClanPartyItemMixin : BaseViewModelMixin<ClanPartyItemVM>
    {
        private static readonly TextObject ManageTroopsLabelText = new TextObject("{=mrcf_manage_troops}Manage Troops");
        private static readonly TextObject ManageTroopsHintText = new TextObject("{=mrcf_manage_troops_hint}Open troop management for this party, caravan, or garrison without leaving the clan screen selection.");

        private bool _isManageTroopsVisible;
        private bool _isManageTroopsEnabled;
        private HintViewModel _manageTroopsHint;
        private string _manageTroopsText;

        public ClanPartyItemMixin(ClanPartyItemVM vm)
            : base(vm)
        {
            _manageTroopsHint = new HintViewModel(ManageTroopsHintText);
            _manageTroopsText = ManageTroopsLabelText.ToString();
            RefreshManageTroopsState();
        }

        public override void OnRefresh()
        {
            RefreshManageTroopsState();
        }

        [DataSourceProperty]
        public bool IsManageTroopsVisible
        {
            get { return _isManageTroopsVisible; }
            set
            {
                if (value == _isManageTroopsVisible)
                    return;
                _isManageTroopsVisible = value;
                OnPropertyChangedWithValue(value, "IsManageTroopsVisible");
            }
        }

        [DataSourceProperty]
        public bool IsManageTroopsEnabled
        {
            get { return _isManageTroopsEnabled; }
            set
            {
                if (value == _isManageTroopsEnabled)
                    return;
                _isManageTroopsEnabled = value;
                OnPropertyChangedWithValue(value, "IsManageTroopsEnabled");
            }
        }

        [DataSourceProperty]
        public HintViewModel ManageTroopsHint
        {
            get { return _manageTroopsHint; }
            set
            {
                if (value == _manageTroopsHint)
                    return;
                _manageTroopsHint = value;
                OnPropertyChangedWithValue(value, "ManageTroopsHint");
            }
        }

        [DataSourceProperty]
        public string ManageTroopsText
        {
            get { return _manageTroopsText; }
            set
            {
                if (value == _manageTroopsText)
                    return;
                _manageTroopsText = value;
                OnPropertyChangedWithValue(value, "ManageTroopsText");
            }
        }

        [DataSourceMethod]
        public void ExecuteManageTroops()
        {
            ClanPartyItemVM partyItem = ViewModel;
            if (!TroopManage.CanManage(partyItem))
                return;

            PartyBase party = partyItem.Party;
            if (party == null)
                return;

            MobileParty mobileParty = party.MobileParty;
            if (mobileParty == null || !mobileParty.IsActive)
                return;

            // Vanilla Helpers.PartyScreenHelper.OpenScreenAsManageTroops(MobileParty) — used by clan troop management.
            PartyScreenHelper.OpenScreenAsManageTroops(mobileParty);
        }

        private void RefreshManageTroopsState()
        {
            bool canManage = TroopManage.CanManage(ViewModel);
            IsManageTroopsVisible = canManage;
            IsManageTroopsEnabled = canManage;
            ManageTroopsText = ManageTroopsLabelText.ToString();
            if (_manageTroopsHint == null)
                ManageTroopsHint = new HintViewModel(ManageTroopsHintText);
        }
    }
}
