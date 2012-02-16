//-----------------------------------------------------------------------
// <copyright file="IVProperty.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Describes an interface that <c>VProperty</c> objects must impement.
    /// </summary>
    public interface IProperty
    {
        /// <summary>
        /// Gets the name of this property.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the named parameters, if any, of this property.
        /// </summary>
        Dictionary<string, string> Parameters { get; }
        
        /// <summary>
        /// Returns the type of the value of this property.
        /// </summary>
        /// <returns>The type of Value</returns>
        Type ValueType();

        /// <summary>
        /// Determines if the <c>Type</c> of this property's value matches
        /// a given type.
        /// </summary>
        /// <param name="type">Type to compare</param>
        /// <returns><c>True</c> if the types match</returns>
        bool MatchesType(Type type);

        /// <summary>
        /// Gets a string representation of this property's value.
        /// </summary>
        /// <returns>Value ToString()</returns>
        string ValueToString();

        /// <summary>
        /// Determines if this property has an empty value, and so should
        /// not be output when saving.
        /// </summary>
        /// <returns><c>True</c> if the property's value is empty.</returns>
        /// <remarks>
        /// Empty has a different definition depending on the property's
        /// <c>T</c> - it could be Guid.Empty, or string.Empty, or null.
        /// </remarks>
        bool IsEmpty();

        /// <summary>
        /// Copies the value and parameters from <paramref name="value"/> to
        /// this property.
        /// </summary>
        /// <param name="value">Property to copy from</param>
        /// <remarks>This is used to preserve the <c>Name</c> key of a property
        /// whilst copying the data from another. Used in 
        /// VProperty.SetProperty.</remarks>
        void CopyFrom(IProperty value);
    }
}
