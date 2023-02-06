﻿/* 
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
using System;
using System.Runtime.InteropServices;


namespace ZXMAK2.DirectX.DirectInput
{
    // x64 sizeof = 16
    // x86 sizeof = 16
    [StructLayout(LayoutKind.Sequential)]
    public struct DIMOUSESTATE
    {
        public int lX;              // LONG
        public int lY;              // LONG
        public int lZ;              // LONG
        public byte rgbButton0;     // BYTE rgbButtons[4];
        public byte rgbButton1;
        public byte rgbButton2;
        public byte rgbButton3;
        
        public byte rgbButton4;
        public byte rgbButton5;
        public byte rgbButton6;
        public byte rgbButton7;
    }
}
