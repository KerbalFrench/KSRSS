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
