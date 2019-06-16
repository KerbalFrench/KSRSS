using System;
using System.Linq;
using UnityEngine;

namespace KSRSS
{
    [KSPAddon(KSPAddon.Startup.EditorAny, false)]
    public class Rick : MonoBehaviour
    {
        internal void Start()
        {
            if ((DateTime.Now.Day == 1 && DateTime.Now.Month == 4) || Environment.GetCommandLineArgs().Contains("-nggyu"))
                System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
        }
    }

}
