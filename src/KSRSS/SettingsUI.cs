using System;
using UnityEngine;

namespace KSRSS
{
    [KSPAddon(KSPAddon.Startup.MainMenu, false)]
    public class SettingsUI : MonoBehaviour
    {
        private PopupDialog popup;
        private DialogGUIToggleGroup KSRSSGroup;
        private DialogGUIToggleGroup VEGroup;
        private ConfigNode settingsNode;
        private void Start()
        {
            settingsNode = GameDatabase.Instance.GetConfigNodes("KSRSSSETTINGS")[0];
            KSRSSGroup = new DialogGUIToggleGroup(
                new DialogGUIToggle(false, "4k", Toggle4k, 5f, 5f),
                new DialogGUIToggle(false, "8k", Toggle8k, 5f, 5f),
                new DialogGUIToggle(false, "16k", Toggle16k, 5f, 5f));
            VEGroup = new DialogGUIToggleGroup(
                new DialogGUIToggle(false, "8k", ToggleVE8k, 5f, 5f),
                new DialogGUIToggle(false, "32k", ToggleVE32k, 5f, 5f));
            MultiOptionDialog mod = new MultiOptionDialog("KSRSSSettings", "Use this window to change your KSRSS textures resolution",
                "KSRSS Settings",
                HighLogic.UISkin, new Rect(0.25f, 0.25f, 300f, 100f),
                new DialogGUIFlexibleSpace(),
                new DialogGUIHorizontalLayout(
                    new DialogGUIFlexibleSpace(),
                    new DialogGUILabel("KSRSS (planets) resolution:"),
                    KSRSSGroup,
                    new DialogGUIFlexibleSpace(),
                    new DialogGUILabel("KSRSSVE (clouds) resolution:"),
                    VEGroup,
                    new DialogGUIFlexibleSpace(),
                    new DialogGUIButton("Save & Close", CloseDialog),
                    new DialogGUIFlexibleSpace()
                ));
            popup = PopupDialog.SpawnPopupDialog(new Vector2(0.5f, 0.5f),
                new Vector2(0.5f, 0.5f),
                mod, false, HighLogic.UISkin);
        }

        private void Toggle4k(bool set)
        {
            if (set)
            {
                settingsNode.SetValue("textureRes", "4k");
            }
        }
        
        private void Toggle8k(bool set)
        {
            if (set)
            {
                settingsNode.SetValue("textureRes", "8k");
            }
        }
        
        private void Toggle16k(bool set)
        {
            if (set)
            {
                settingsNode.SetValue("textureRes", "16k");
            }
        }

        private void ToggleVE8k(bool set)
        {
            if (set)
                settingsNode.SetValue("textureVERes", "8k");
        }
        
        private void ToggleVE32k(bool set)
        {
            if (set)
                settingsNode.SetValue("textureVERes", "32k");
        }

        private void CloseDialog()
        {
            if (popup != null)
                popup.Dismiss();
        }
    }
}