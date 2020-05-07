/*  Copyright (c) KSRSS Team - 2020
    This file is part of KSRSS.dll.

    KSRSS.dll is free software: you can redistribute it and/or modify
    it under the terms of the GNU Lesser General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    KSRSS.dll is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public License
    along with KSRSS.dll.  If not, see <https://www.gnu.org/licenses/>.
*/
using UnityEngine;
using System.IO;

namespace KSRSS
{
    [KSPAddon(KSPAddon.Startup.Instantly, false)]
    public class Recommandation : MonoBehaviour
    {
        private PopupDialog dialog;
        void Start()
        {
            bool isVeInstalled = Directory.Exists(KSPUtil.ApplicationRootPath + "GameData/KSRSSVE");
            if (!isVeInstalled)
            {
                dialog = PopupDialog.SpawnPopupDialog(new Vector2(0.5f, 0.5f),
                    new Vector2(0.5f, 0.5f),
                    new MultiOptionDialog("KSRSSRecommandation",
                        "KSRSSVE is not a KSRSS dependency, but is highly recommended.\nIf you have a good PC, please consider installing KSRSSVE.",
                        "KSRSS",
                        HighLogic.UISkin, new Rect(0.5f, 0.5f, 300f, 100f),
                        new DialogGUIFlexibleSpace(),
                        new DialogGUIHorizontalLayout(
                            new DialogGUIFlexibleSpace(),
                            new DialogGUIButton("OK", CloseDialog, 140.0f, 30.0f, true),
                            new DialogGUIFlexibleSpace()
                        )), false, HighLogic.UISkin);
            }
        }

        void CloseDialog()
        {
            if (dialog != null)
                dialog.Dismiss();
        }
    }
}