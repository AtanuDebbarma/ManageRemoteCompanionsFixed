using Bannerlord.UIExtenderEx.Attributes;
using Bannerlord.UIExtenderEx.Prefabs2;

namespace ManageRemoteCompanionsFix
{
    // Bannerlord 1.5.7 / War Sails 1.3.7: ClanPartiesRightPanel no longer has HeroNameParent.
    // Insert Manage Troops at the top of PartiesRightPanelControls (present in SandBox and NavalDLC).
    [PrefabExtension("ClanPartiesRightPanel", "descendant::ListPanel[@Id='PartiesRightPanelControls']/Children")]
    internal sealed class ClanPartiesRightPanelPrefab : PrefabExtensionInsertPatch
    {
        public override InsertType Type
        {
            get { return InsertType.Child; }
        }

        public override int Index
        {
            get { return 0; }
        }

        [PrefabExtensionText]
        public string Text
        {
            get
            {
                return
                    "<ListPanel Id=\"ManageTroopsParent\" WidthSizePolicy=\"Fixed\" HeightSizePolicy=\"Fixed\" " +
                    "SuggestedWidth=\"335\" SuggestedHeight=\"40\" HorizontalAlignment=\"Center\" MarginTop=\"10\" " +
                    "UpdateChildrenStates=\"true\" IsVisible=\"@IsManageTroopsVisible\">" +
                    "<Children>" +
                    "<ButtonWidget Id=\"ManageTroopsButton\" DoNotPassEventsToChildren=\"true\" UpdateChildrenStates=\"true\" " +
                    "WidthSizePolicy=\"StretchToParent\" HeightSizePolicy=\"StretchToParent\" " +
                    "Brush=\"ButtonBrush2\" Command.Click=\"ExecuteManageTroops\" IsEnabled=\"@IsManageTroopsEnabled\" " +
                    "GamepadNavigationIndex=\"0\">" +
                    "<Children>" +
                    "<TextWidget WidthSizePolicy=\"StretchToParent\" HeightSizePolicy=\"StretchToParent\" " +
                    "Brush=\"Kingdom.GeneralButtons.Text\" Text=\"@ManageTroopsText\" />" +
                    "<HintWidget DataSource=\"{ManageTroopsHint}\" WidthSizePolicy=\"StretchToParent\" HeightSizePolicy=\"StretchToParent\" " +
                    "Command.HoverBegin=\"ExecuteBeginHint\" Command.HoverEnd=\"ExecuteEndHint\" IsDisabled=\"true\" />" +
                    "</Children>" +
                    "</ButtonWidget>" +
                    "</Children>" +
                    "</ListPanel>";
            }
        }
    }
}
