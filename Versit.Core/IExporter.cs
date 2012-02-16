//-----------------------------------------------------------------------
// <copyright file="IVObject.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.Core
{
    using System.IO;
using System.Text;

    /// <summary>
    /// Provides export functionality to a given format.
    /// </summary>
    public interface IExporter
    {
        /// <summary>
        /// Writes the beginning tag of an object.
        /// </summary>
        /// <param name="obj">Object to write</param>
        void WriteBeginTag(IVersitObject obj);

        /// <summary>
        /// Writes the end tag of an object.
        /// </summary>
        /// <param name="obj">Object to write</param>
        void WriteEndTag(IVersitObject obj);

        /// <summary>
        /// Writes out a property.
        /// </summary>
        /// <param name="property">Property to write</param>
        void WriteProperty(IProperty property);

        /// <summary>
        /// Writes the exported versit object to a stream.
        /// </summary>
        /// <returns>A Stream object</returns>
        Stream ToStream();

        /// <summary>
        /// Writes the exported versit object to a stream.
        /// </summary>
        /// <param name="encoding">Type of encoding to use</param>
        /// <returns>A Stream object</returns>
        Stream ToStream(Encoding encoding);
    }
}
