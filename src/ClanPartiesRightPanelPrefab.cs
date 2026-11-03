using Bannerlord.UIExtenderEx.Attributes;
using Bannerlord.UIExtenderEx.Prefabs2;

namespace ManageRemoteCompanionsFix
{
    // Inserts Manage Troops beside Change Leader inside HeroNameParent (SandBox + NavalDLC).
    // Must use Child (not Append): Append would insert a stretched sibling under the name row.
    [PrefabExtension("ClanPartiesRightPanel", "descendant::ListPanel[@Id='HeroNameParent']/Children")]
    internal sealed class ClanPartiesRightPanelPrefab : PrefabExtensionInsertPatch
    {
        public override InsertType Type
        {
            get { return InsertType.Child; }
        }

        // After Name TextWidget (0) and Change Leader wrapper (1).
        public override int Index
        {
            get { return 2; }
        }

        [PrefabExtensionText]
        public string Text
        {
            get
            {
                // Same action-button look as Kingdom Manage/Disband (ButtonBrush2, 227x40).
                return
                    "<ButtonWidget Id=\"ManageTroopsButton\" DoNotPassEventsToChildren=\"true\" UpdateChildrenStates=\"true\" " +
                    "WidthSizePolicy=\"Fixed\" HeightSizePolicy=\"Fixed\" SuggestedWidth=\"160\" SuggestedHeight=\"40\" " +
                    "VerticalAlignment=\"Center\" MarginLeft=\"12\" Brush=\"ButtonBrush2\" " +
                    "Command.Click=\"ExecuteManageTroops\" IsVisible=\"@IsManageTroopsVisible\" IsEnabled=\"@IsManageTroopsEnabled\" " +
                    "GamepadNavigationIndex=\"1\">" +
                    "<Children>" +
                    "<TextWidget WidthSizePolicy=\"StretchToParent\" HeightSizePolicy=\"StretchToParent\" " +
                    "Brush=\"Kingdom.GeneralButtons.Text\" Text=\"@ManageTroopsText\" />" +
                    "<HintWidget DataSource=\"{ManageTroopsHint}\" WidthSizePolicy=\"StretchToParent\" HeightSizePolicy=\"StretchToParent\" " +
                    "Command.HoverBegin=\"ExecuteBeginHint\" Command.HoverEnd=\"ExecuteEndHint\" IsDisabled=\"true\" />" +
                    "</Children>" +
                    "</ButtonWidget>";
            }
        }
    }
}
