//-----------------------------------------------------------------------
// <copyright file="TelephoneType.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.VCard
{
    /// <summary>
    /// Enumerates types of telephone number.
    /// </summary>
    public enum TelephoneType
    {
        /// <summary>
        /// Indicates a voice number (Default)
        /// </summary>
        VOICE,

        /// <summary>
        /// Indicates a preferred/primary number
        /// </summary>
        PREF,

        /// <summary>
        /// Indicates a work number
        /// </summary>
        WORK,

        /// <summary>
        /// Indicates a home number
        /// </summary>
        HOME,

        /// <summary>
        /// Indicates a facsimile number
        /// </summary>
        FAX,

        /// <summary>
        /// Indicates a messaging service on the number
        /// </summary>
        MSG,

        /// <summary>
        /// Indicates a cellular number
        /// </summary>
        CELL,

        /// <summary>
        /// Indicates a pager number
        /// </summary>
        PAGER,

        /// <summary>
        /// Indicates a bulletin board service number
        /// </summary>
        BBS,

        /// <summary>
        /// Indicates a MODEM number
        /// </summary>
        MODEM,

        /// <summary>
        /// Indicates a car-phone number
        /// </summary>
        CAR,

        /// <summary>
        /// Indicates an ISDN number
        /// </summary>
        ISDN,

        /// <summary>
        /// Indicates a video-phone number
        /// </summary>
        VIDEO
    }
}
