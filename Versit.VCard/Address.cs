//-----------------------------------------------------------------------
// <copyright file="Address.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.VCard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Versit.Core;

    /// <summary>
    /// Represents a postal address.
    /// </summary>
    public class Address : Property<string[]>
    {
        /// <summary>
        /// Initializes a new instance of the Address class.
        /// </summary>
        public Address() :
            base("ADR", new string[9])
        {
            this.Parameters.Clear();
            this.Parameters.Add("TYPE", AddressType.WORK.ToString());
        }

        /// <summary>
        /// Gets or sets the PO Box number of this address.
        /// </summary>
        public string PostOfficeBox
        {
            get { return Value[0]; }
            set { Value[0] = value; }
        }

        /// <summary>
        /// Gets or sets the extended address.
        /// </summary>
        public string ExtendedAddress
        {
            get { return Value[1]; }
            set { Value[1] = value; }
        }

        /// <summary>
        /// Gets or sets the street address.
        /// </summary>
        public string StreetAddress
        {
            get { return Value[2]; }
            set { Value[2] = value; }
        }

        /// <summary>
        /// Gets or sets the town or city.
        /// </summary>
        public string Locality
        {
            get { return Value[3]; }
            set { Value[3] = value; }
        }

        /// <summary>
        /// Gets or sets the region (county, state, area).
        /// </summary>
        public string Region
        {
            get { return Value[4]; }
            set { Value[4] = value; }
        }

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        public string PostalCode
        {
            get { return Value[5]; }
            set { Value[5] = value; }
        }

        /// <summary>
        /// Gets or sets the country name.
        /// </summary>
        public string Country
        {
            get { return Value[6]; }
            set { Value[6] = value; }
        }

        /// <summary>
        /// Gets or sets the type of this address.
        /// </summary>
        public AddressType AddressType
        {
            get { return GetEnumParameter<AddressType>("TYPE"); }
            set { SetParameter("TYPE", value); }
        }
    }
}
