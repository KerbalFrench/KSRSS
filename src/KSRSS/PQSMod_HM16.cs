/*  Copyright (c) 2017-2019 Dorian "StollD" Stoll
    Copyright (c) 2020 TheGhastModding
    Copyright (c) 2020 VabienArt
    Copyright (c) 2020 KSRSS Team
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
namespace KSRSS
{
    public class PQSMod_HM16 : PQSMod_VertexHeightMap
    {
        public override void OnVertexBuildHeight(PQS.VertexBuildData data)
        {
            data.vertHeight += heightMapOffset + heightMapDeformity * HM16.SampleHeightmap16(data.u, data.v, heightMap, false);
        }
    }
}