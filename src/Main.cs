using System;
using Bannerlord.UIExtenderEx;
using HarmonyLib;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace ManageRemoteCompanionsFix
{
    // 1.4.8 fix/continuation of Manage Remote Companions by RadthorDax (Nexus 698).
    // https://www.nexusmods.com/mountandblade2bannerlord/mods/698
    internal class Main : MBSubModuleBase
    {
        private UIExtender _uiExtender;

        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            try
            {
                _uiExtender = UIExtender.Create("ManageRemoteCompanionsFix");
                _uiExtender.Register(typeof(Main).Assembly);
                _uiExtender.Enable();
            }
            catch (Exception e)
            {
                InformationManager.DisplayMessage(new InformationMessage(
                    "ManageRemoteCompanionsFix UIExtender failed: " + e.Message));
                Debug.Print("[ManageRemoteCompanionsFix] UIExtender " + e);
            }

            try
            {
                new Harmony("com.atanu.bannerlord.ManageRemoteCompanionsFix").PatchAll();
            }
            catch (Exception e)
            {
                InformationManager.DisplayMessage(new InformationMessage(
                    "ManageRemoteCompanionsFix patch failed: " + e.Message));
                Debug.Print("[ManageRemoteCompanionsFix] " + e);
            }
        }
    }
}
