/* 
 *  Copyright 2008-2018 Alex Makeev
 * 
 *  This file is part of ZXMAK2 (ZX Spectrum virtual machine).
 *
 *  ZXMAK2 is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  ZXMAK2 is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with ZXMAK2.  If not, see <http://www.gnu.org/licenses/>.
 *
 *  Description: DirectX native wrapper
 *  Date: 15.07.2018
 */


namespace ZXMAK2.DirectX.Direct3D
{
    // d3d9types.h
    public enum D3DCLEAR
    {
        /// <summary>
        /// Clear target surface
        /// </summary>
        /// <unmanaged>D3DCLEAR_TARGET</unmanaged>
        TARGET            = 0x00000001,
        /// <summary>
        /// Clear target z buffer
        /// </summary>
        /// <unmanaged>D3DCLEAR_ZBUFFER</unmanaged>
        ZBUFFER           = 0x00000002,
        /// <summary>
        /// Clear stencil planes
        /// </summary>
        /// <unmanaged>D3DCLEAR_STENCIL</unmanaged>
        STENCIL           = 0x00000004,
    }
}
