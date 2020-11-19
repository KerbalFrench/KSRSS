/*using System.Collections.Generic;
using UnityEngine;
using Kopernicus;
using Kopernicus.Configuration;
using Expansions;
using System.Reflection;

namespace KSRSS
{
    public struct HSV
    {
        public float H;
        public float S;
        public float V;
    }
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class ROCColor : MonoBehaviour
    {
        

        private void Start()
        {
            if (!ExpansionsLoader.IsExpansionInstalled("Serenity"))
            {
                return;
            }

            CelestialBody mars = FlightGlobals.fetch.bodies.Find(b => b.displayName == "Mars");

            if (mars == null)
            {
                Debug.Log("[KSRSS] Mars is nulll");
                return;
            }
            
            PQSROCControl rockController = mars.pqsController.GetComponentInChildren<PQSROCControl>();
            List<LandClassROC> landClasses = rockController.rocs;
            LandClassROC rocClass = landClasses.Find(lc => lc.rocType.displayName == "Mars Dune");
            GameObject rocObject = (GameObject)rocClass.GetType().GetField("rocObject", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(rocClass);
            if (rocObject == null)
            {
                Debug.Log("[KSRSS] rocObject is nulllllll");
            }
            Color RGBColor = rocObject.GetComponent<Renderer>().material.GetColor("_Color");
            HSV HSVColor = new HSV();
            Color.RGBToHSV(RGBColor, out HSVColor.H, out HSVColor.S, out HSVColor.V);
            HSVColor.S = 0f;
            rocObject.GetComponent<Renderer>().material
                .SetColor("_Color", Color.HSVToRGB(HSVColor.H, HSVColor.S, HSVColor.V)); 
            
            
            //GameObject duneObject = mars.pqsController.transform.Find("ROCDunaDune").gameObject;
            //for (int i = 0; i < duneObject.transform.childCount; i++)
            //{
            //    duneObject.transform.GetChild(i).Find("dunaDune(Clone)(Clone)/dunaDune_LOD00").gameObject.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", Color.blue);
            //}
        }
    }
}*/