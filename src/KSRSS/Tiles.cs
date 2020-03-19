﻿// This file is NOT licensed LGPLv3.
// This file is licensed CC-BY-NC-SA 4.0 and was modified by the KSRSS Team. 
// Original file can be found here https://github.com/KSP-RO/RealSolarSystem/blob/master/Source/Watchdogs.cs by KSP-RO Team
using System;
using UnityEngine;

namespace KSRSS
{
    [KSPAddon(KSPAddon.Startup.FlightAndKSC, false)]
    public class TilesFix : MonoBehaviour
    {
        protected bool isSuborbital = false;

        public void Start()
        {
            GameEvents.onVesselSituationChange.Add(OnSituationChanged);
        }

        public void OnDestroy()
        {
            GameEvents.onVesselSituationChange.Remove(OnSituationChanged);
        }

        private void OnSituationChanged(GameEvents.HostedFromToAction<Vessel, Vessel.Situations> data)
        {
            Vessel curVessel = data.host;
            if (!curVessel.mainBody.isHomeWorld || !curVessel.isActiveVessel) return;

            if (data.from == Vessel.Situations.FLYING && data.to == Vessel.Situations.SUB_ORBITAL)
            {
                isSuborbital = true;
            }
            else if (isSuborbital && data.to == Vessel.Situations.FLYING)
            {
                isSuborbital = false;
                Debug.Log("[KSRSS]: Calling StartUpSphere() to prevent missing PQ tiles");
                curVessel.mainBody.pqsController.StartUpSphere();
            }
        }
    }
}
