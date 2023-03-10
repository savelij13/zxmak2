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
using System;
using System.Runtime.InteropServices;
using ZXMAK2.DirectX.Native;


namespace ZXMAK2.DirectX.Direct3D
{
    /// <unmanaged>IDirect3DVertexBuffer9</unmanaged>	
    [Guid("B64BB1B5-FD70-4df6-BF91-19D0A12455E3")]
    public class Direct3DVertexBuffer9 : Direct3DResource9
    {
        public Direct3DVertexBuffer9(IntPtr nativePointer)
            : base(nativePointer)
        {
        }


        /// <unmanaged>HRESULT IDirect3DVertexBuffer9::Lock([In] unsigned int OffsetToLock,[In] unsigned int SizeToLock,[Out] void** ppbData,[In] D3DLOCK Flags)</unmanaged>	
        public unsafe HRESULT Lock(int offsetToLock, int sizeToLock, void** ppbData, D3DLOCK lockFlags)
        {
            //result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Void*,System.Int32), this._nativePointer, offsetToLock, sizeToLock, ptr, lockFlags, *(*(IntPtr*)this._nativePointer + (IntPtr)11 * (IntPtr)sizeof(void*)));
            return (HRESULT)NativeHelper.CalliInt32(11, _nativePointer, (int)offsetToLock, (int)sizeToLock, (void*)ppbData, (int)lockFlags);
        }

        /// <unmanaged>HRESULT IDirect3DVertexBuffer9::Unlock()</unmanaged>	
        public unsafe HRESULT Unlock()
		{
			//calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*))).CheckError();
            return NativeHelper.CalliInt32(12, _nativePointer);
		}
    }
}
