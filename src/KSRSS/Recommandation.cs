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

using System;
using UnityEngine;
using System.IO;
using System.Xml;

namespace KSRSS
{
    [KSPAddon(KSPAddon.Startup.Instantly, false)]
    public class Recommandation : MonoBehaviour
    {
        private PopupDialog dialog;
        private XmlNode popupNode;
        private XmlDocument doc;
        void Start()
        {
            bool isVeInstalled = Directory.Exists(KSPUtil.ApplicationRootPath + "GameData/KSRSSVE");
            doc = new XmlDocument();
            if (File.Exists(KSPUtil.ApplicationRootPath + "GameData/KSRSS/KSRSSSettings.xml"))
            {
                doc.Load(KSPUtil.ApplicationRootPath + "GameData/KSRSS/KSRSSSettings.xml");
            }
            else
            {
                doc.LoadXml(@"<KSRSSSettings>
                    <showPopup>True</showPopup>
                    </KSRSSSettings>");
            }
            popupNode = doc.DocumentElement.SelectSingleNode("/KSRSSSettings/showPopup");
            string showPopup = popupNode.InnerText;
            if (!isVeInstalled && showPopup.Equals("True"))
            {
                dialog = PopupDialog.SpawnPopupDialog(new Vector2(0.5f, 0.5f),
                    new Vector2(0.5f, 0.5f),
                    new MultiOptionDialog("KSRSSRecommandation",
                        "KSRSSVE is not a KSRSS dependency, but is highly recommended.\nIf you have a good PC, please consider installing KSRSSVE.",
                        "KSRSS",
                        HighLogic.UISkin, new Rect(0.5f, 0.5f, 350f, 100f),
                        new DialogGUIFlexibleSpace(),
                        new DialogGUIToggle(false, "Do not show this popup anymore",
                            ChangeXml, 100f, 40f),
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
        
        void ChangeXml(bool set)
        {
            if (set)
            {
                popupNode.InnerText = "False";
            }
            else
            {
                popupNode.InnerText = "True";
            }

            doc.Save(KSPUtil.ApplicationRootPath + "GameData/KSRSS/KSRSSSettings.xml");
        }
    }
}