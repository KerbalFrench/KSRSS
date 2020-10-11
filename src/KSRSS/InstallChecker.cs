/*  Copyright (c) 2020 KSRSS Team
    This file is part of KSRSS.dll.

    KSRSS.dll is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    KSRSS.dll is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with KSRSS.dll.  If not, see <https://www.gnu.org/licenses/>.
*/
using System.IO;
using UnityEngine;

namespace KSRSS
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    internal class InstallChecker : MonoBehaviour
    {
        internal void Start()
        {
            bool isTextInstalled = Directory.Exists(KSPUtil.ApplicationRootPath + "GameData/KSRSS-Textures");
            bool isVeInstalled = Directory.Exists(KSPUtil.ApplicationRootPath + "GameData/KSRSSVE");
            bool isVeTextInstalled = Directory.Exists(KSPUtil.ApplicationRootPath + "GameData/KSRSSVE/Textures");
            string message = "";

            if (!isTextInstalled)
            {
                message += "ERROR : KSRSS-Textures is missing!\nPlease install KSRSS-Textures and restart KSP.\n";
            }

            if (isVeInstalled && !isVeTextInstalled)
            {
                message += "ERROR : KSRSSVE-Textures is missing!\nPlease install KSRSSVE-Textures and restart KSP.\n";
            }

            if (!message.Equals(""))
            {
                PopupDialog.SpawnPopupDialog(new Vector2(0.5f, 0.5f),
                    new Vector2(0.5f, 0.5f),
                    new MultiOptionDialog("KSRSSInstallChecker", message, "KSRSS Install Checker",
                        HighLogic.UISkin, new Rect(0.5f, 0.5f, 300f, 100f),
                        new DialogGUIFlexibleSpace(),
                        new DialogGUIHorizontalLayout(
                            new DialogGUIFlexibleSpace(),
                            new DialogGUIButton("Quit", Application.Quit, 140.0f, 30.0f, true),
                            new DialogGUIFlexibleSpace()
                        )), true, HighLogic.UISkin);
            }
        }
    }
}