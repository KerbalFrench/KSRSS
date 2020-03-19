using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using CommNet;

namespace KSRSS
{
    [KSPAddon(KSPAddon.Startup.SpaceCentre, false)]
    public class CommNetModifier : MonoBehaviour
    {
        public void Start()
        {
            HighLogic.CurrentGame.Parameters.CustomParams<CommNetParams>().DSNModifier = 6;
        }
    }
}
