﻿#region License
//
// Jdenticon-net
// https://github.com/dmester/jdenticon-net
// Copyright © Daniel Mester Pirttijärvi 2016
//
// This software is provided 'as-is', without any express or implied
// warranty.In no event will the authors be held liable for any damages
// arising from the use of this software.
// 
// Permission is granted to anyone to use this software for any purpose,
// including commercial applications, and to alter it and redistribute it
// freely, subject to the following restrictions:
// 
// 1. The origin of this software must not be misrepresented; you must not
//    claim that you wrote the original software.If you use this software
//    in a product, an acknowledgment in the product documentation would be
//    appreciated but is not required.
// 
// 2. Altered source versions must be plainly marked as such, and must not be
//    misrepresented as being the original software.
// 
// 3. This notice may not be removed or altered from any source distribution.
//
#endregion

using Jdenticon.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Jdenticon
{
    /// <summary>
    /// Extends <see cref="Identicon"/> with SVG specific methods.
    /// </summary>
    public static class SvgExtensions
    {
        private static void GenerateSvg(this Identicon icon, TextWriter writer, int size, bool fragment)
        {
            var iconBounds = icon.GetIconBounds(size);
            var renderer = new SvgRenderer(size, size);
            icon.Draw(renderer, iconBounds);
            renderer.Save(writer, fragment);
        }

        /// <summary>
        /// Creates a string containing an SVG version of this icon.
        /// </summary>
        /// <param name="icon">Icon instance.</param>
        /// <param name="size">The size of the generated icon in pixels.</param>
        public static string ToSvg(this Identicon icon, int size)
        {
            return icon.ToSvg(size, false);
        }

        /// <summary>
        /// Creates a string containing an SVG version of this icon.
        /// </summary>
        /// <param name="icon">Icon instance.</param>
        /// <param name="size">The size of the generated icon in pixels.</param>
        /// <param name="fragment">
        /// If <c>true</c> the generated SVG will not be encapsulated in the root svg element making 
        /// it suitable to be embedded in another SVG.
        /// </param>
        public static string ToSvg(this Identicon icon, int size, bool fragment)
        {
            using (var writer = new StringWriter())
            {
                icon.GenerateSvg(writer, size, fragment);
                return writer.ToString();
            }
        }



        /// <summary>
        /// Saves this icon as an SVG file.
        /// </summary>
        /// <param name="icon">Icon instance.</param>
        /// <param name="writer">The <see cref="TextWriter"/> to which the icon will be written.</param>
        /// <param name="size">The size of the generated icon in pixels.</param>
        /// <exception cref="ArgumentNullException"><paramref name="writer"/> was <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="size"/> less than 1 pixel.</exception>
        public static void SaveAsSvg(this Identicon icon, TextWriter writer, int size)
        {
            icon.SaveAsSvg(writer, size, false);
        }

        /// <summary>
        /// Saves this icon as an SVG file.
        /// </summary>
        /// <param name="icon">Icon instance.</param>
        /// <param name="stream">The stream to which the icon will be written.</param>
        /// <param name="size">The size of the generated icon in pixels.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> was <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="size"/> less than 1 pixel.</exception>
        public static void SaveAsSvg(this Identicon icon, Stream stream, int size)
        {
            icon.SaveAsSvg(stream, size, false);
        }

#if HAVE_FILE_STREAM
        /// <summary>
        /// Saves this icon as an SVG file.
        /// </summary>
        /// <param name="icon">Icon instance.</param>
        /// <param name="path">The path to the file to which the icon will be written.</param>
        /// <param name="size">The size of the generated icon in pixels.</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> was <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="size"/> less than 1 pixel.</exception>
        public static void SaveAsSvg(this Identicon icon, string path, int size)
        {
            icon.SaveAsSvg(path, size, false);
        }
#endif


        /// <summary>
        /// Saves this icon as an SVG file.
        /// </summary>
        /// <param name="icon">Icon instance.</param>
        /// <param name="writer">The <see cref="TextWriter"/> to which the icon will be written.</param>
        /// <param name="size">The size of the generated icon in pixels.</param>
        /// <param name="fragment">
        /// If <c>true</c> the generated SVG will not be encapsulated in the root svg element making 
        /// it suitable to be embedded in another SVG.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="writer"/> was <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="size"/> less than 1 pixel.</exception>
        public static void SaveAsSvg(this Identicon icon, TextWriter writer, int size, bool fragment)
        {
            if (size < 1) throw new ArgumentOutOfRangeException(nameof(size), size, "The size should be 1 pixel or larger.");
            if (writer == null) throw new ArgumentNullException(nameof(writer));

            icon.GenerateSvg(writer, size, fragment);
        }

        /// <summary>
        /// Saves this icon as an SVG file.
        /// </summary>
        /// <param name="icon">Icon instance.</param>
        /// <param name="stream">The stream to which the icon will be written.</param>
        /// <param name="size">The size of the generated icon in pixels.</param>
        /// <param name="fragment">
        /// If <c>true</c> the generated SVG will not be encapsulated in the root svg element making 
        /// it suitable to be embedded in another SVG.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> was <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="size"/> less than 1 pixel.</exception>
        public static void SaveAsSvg(this Identicon icon, Stream stream, int size, bool fragment)
        {
            if (size < 1) throw new ArgumentOutOfRangeException(nameof(size), size, "The size should be 1 pixel or larger.");
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            using (var writer = new StreamWriter(stream, Encoding.UTF8))
            {
                icon.SaveAsSvg(writer, size, fragment);
            }
        }

        /// <summary>
        /// Saves this icon as an SVG file.
        /// </summary>
        /// <param name="icon">Icon instance.</param>
        /// <param name="size">The size of the generated icon in pixels.</param>
        /// <param name="fragment">
        /// If <c>true</c> the generated SVG will not be encapsulated in the root svg element making 
        /// it suitable to be embedded in another SVG.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="size"/> less than 1 pixel.</exception>
        public static Stream SaveAsSvg(this Identicon icon, int size, bool fragment)
        {
            var memoryStream = new MemoryStream();
            icon.SaveAsSvg(memoryStream, size, fragment);
            memoryStream.Position = 0;
            return memoryStream;
        }

        /// <summary>
        /// Saves this icon as an SVG file.
        /// </summary>
        /// <param name="icon">Icon instance.</param>
        /// <param name="size">The size of the generated icon in pixels.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="size"/> less than 1 pixel.</exception>
        public static Stream SaveAsSvg(this Identicon icon, int size)
        {
            return SaveAsSvg(icon, size, false);
        }

#if HAVE_FILE_STREAM
        /// <summary>
        /// Saves this icon as an SVG file.
        /// </summary>
        /// <param name="icon">Icon instance.</param>
        /// <param name="path">The path to the file to which the icon will be written.</param>
        /// <param name="size">The size of the generated icon in pixels.</param>
        /// <param name="fragment">
        /// If <c>true</c> the generated SVG will not be encapsulated in the root svg element making 
        /// it suitable to be embedded in another SVG.
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> was <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="size"/> less than 1 pixel.</exception>
        public static void SaveAsSvg(this Identicon icon, string path, int size, bool fragment)
        {
            if (size < 1) throw new ArgumentOutOfRangeException(nameof(size), size, "The size should be 1 pixel or larger.");
            if (path == null) throw new ArgumentNullException("path");

            using (var stream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            {
                icon.SaveAsSvg(stream, size, fragment);
            }
        }
#endif
    }
}
