/*  Copyright (c) KSRSS Team - 2020
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
