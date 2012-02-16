//-----------------------------------------------------------------------
// <copyright file="IVObject.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.Core
{
    using System.Collections.Generic;

    /// <summary>
    /// Describes an interface that all <c>VOjects</c> must implement.
    /// </summary>
    public interface IVersitObject
    {
        /// <summary>
        /// Gets the version of the versit standard this object implements.
        /// </summary>
        string Version { get; }

        /// <summary>
        /// Gets the <c>VOjectType</c> of this object.
        /// </summary>
        VersitObjectType Type { get; }

        /// <summary>
        /// Export the data in this object to an exporter.
        /// </summary>
        /// <param name="exporter">Exporter object to perform the operation</param>
        void Export(IExporter exporter);
    }
}
