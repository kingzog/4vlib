//-----------------------------------------------------------------------
// <copyright file="AddressType.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.VCard
{
    /// <summary>
    /// Enumerates the sub-types of physical delivery that is associated with the delivery address.
    /// </summary>
    public enum AddressType
    {
        /// <summary>
        /// Indicates a domestic address
        /// </summary>
        DOM,

        /// <summary>
        /// Indicates an international address
        /// </summary>
        INTL,

        /// <summary>
        /// Indicates a postal delivery address
        /// </summary>
        POSTAL,

        /// <summary>
        /// Indicates a parcel delivery address
        /// </summary>
        PARCEL,

        /// <summary>
        /// Indicates a home delivery address
        /// </summary>
        HOME,

        /// <summary>
        /// Indicates a work delivery address
        /// </summary>
        WORK
    }
}
