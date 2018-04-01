﻿#region License
// Jdenticon-net
// https://github.com/dmester/jdenticon-net
// Copyright © Daniel Mester Pirttijärvi 2016
//
// Permission is hereby granted, free of charge, to any person obtaining 
// a copy of this software and associated documentation files (the 
// "Software"), to deal in the Software without restriction, including 
// without limitation the rights to use, copy, modify, merge, publish, 
// distribute, sublicense, and/or sell copies of the Software, and to 
// permit persons to whom the Software is furnished to do so, subject to 
// the following conditions:
// 
// The above copyright notice and this permission notice shall be 
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY 
// CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, 
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Jdenticon.Rendering
{
    // This file contains deprecated members
    partial struct Color
    {
        #region Methods
        
        /// <exclude/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method does not return an ARGB value, but rather an RGBA value. Use ToRgba instead.")]
        public uint ToArgb()
        {
            return value;
        }

        /// <exclude/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method does not operate on ARGB color values as suggested by its name. Use FromRgba instead.")]
        public static Color FromArgb(uint rgba)
        {
            return new Color(rgba);
        }

        #endregion
    }
}
