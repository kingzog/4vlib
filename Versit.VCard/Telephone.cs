//-----------------------------------------------------------------------
// <copyright file="Telephone.cs" company="4verse">
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
    /// Represents a telephone number.
    /// </summary>
    public class Telephone : Property<string>
    {
        /// <summary>
        /// Initializes a new instance of the Telephone class.
        /// </summary>
        public Telephone()
            : base("TEL", string.Empty)
        {
            this.CountryCode = 1;
            this.Name = "TEL";
            this.TelephoneType = TelephoneType.VOICE;
        }

        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        /// <example>44</example>
        public int CountryCode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of number.
        /// </summary>
        public TelephoneType TelephoneType
        {
            get { return GetEnumParameter<TelephoneType>("TYPE"); }
            set { this.Parameters["TYPE"] = value.ToString(); }
        }

        /// <summary>
        /// Gets or sets the area code (optional).
        /// </summary>
        /// <remarks>
        /// If given, this will be incorporated into the string 
        /// representation of the number, as given by calling
        /// <c>ValueToString()</c>.
        /// </remarks>
        /// <example>01904</example>
        public string AreaCode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the extension.
        /// </summary>
        /// <example>34</example>
        public string Extension
        {
            get;
            set;
        }

        /// <summary>
        /// Returns the formatted telephone number as a string.
        /// </summary>
        /// <returns>A formatted telephone number</returns>
        /// <example>
        ///     <code>
        ///         var tel = new VTelephone { CountryCode = 44, AreaCode = "01904", Value = "691515" };
        ///         var formattedTel = tel.ValueToString();
        ///     </code>
        ///     <para>The value of <c>formattedTel</c> would be <c>+44 (01904) 691515</c>.</para>
        /// </example>
        public override string ValueToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("+{0} ", this.CountryCode);

            if (!string.IsNullOrEmpty(this.AreaCode))
            {
                sb.AppendFormat("({0})", this.AreaCode);
            }

            sb.Append(this.Value);
            return sb.ToString();
        }
    }
}
