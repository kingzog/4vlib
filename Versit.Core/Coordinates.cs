//-----------------------------------------------------------------------
// <copyright file="Coordinates.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.Core
{
    using System.Globalization;

    /// <summary>
    /// Represents a set of geographical co-ordinates.
    /// </summary>
    public struct Coordinates
    {
        // TODO: Convert Coordinates to VGeo class

        /// <summary>
        /// The latitude of these co-ordinates.
        /// </summary>
        private double? latitude;

        /// <summary>
        /// The longitude of these co-ordinates.
        /// </summary>
        private double? longitude;

        /// <summary>
        /// Initializes a new instance of the Coordinates struct.
        /// </summary>
        /// <param name="latitude">Latitude value</param>
        /// <param name="longitude">Longitude value</param>
        public Coordinates(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        /// <summary>
        /// Gets the latitude of these co-ordinates.
        /// </summary>
        public double? Latitude
        {
            get { return this.latitude; }
        }

        /// <summary>
        /// Gets the longitude of these co-ordinates.
        /// </summary>
        public double? Longitude
        {
            get { return this.longitude; }
        }

        /// <summary>
        /// Indicates whether two Coordinates instances are equal.
        /// </summary>
        /// <param name="coordinates1">First Coordinates</param>
        /// <param name="coordinates2">Second Coordinates</param>
        /// <returns>True if equal</returns>
        public static bool operator ==(Coordinates coordinates1, Coordinates coordinates2)
        {
            return coordinates1.Latitude == coordinates2.Latitude &&
                coordinates1.Longitude == coordinates2.Longitude;
        }

        /// <summary>
        /// Indicates whether two Coordinates instances are not equal.
        /// </summary>
        /// <param name="coordinates1">First Coordinates</param>
        /// <param name="coordinates2">Second Coordinates</param>
        /// <returns>True if not equal</returns>
        public static bool operator !=(Coordinates coordinates1, Coordinates coordinates2)
        {
            return !(coordinates1 == coordinates2);
        }

        /// <summary>
        /// Returns a string representation of these co-ordinates.
        /// </summary>
        /// <returns>The co-ordinates in string form</returns>
        /// <example>37.386013;-122.082932</example>
        /// <remarks>Formatted to Versit standards.</remarks>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0:d};{1:d}", this.latitude, this.longitude);
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>True if equal</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A hash code</returns>
        public override int GetHashCode()
        {
            return this.latitude.GetHashCode() +
                this.longitude.GetHashCode();
        }
    }
}
