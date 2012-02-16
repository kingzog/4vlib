//-----------------------------------------------------------------------
// <copyright file="VText.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.Core
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A property containing human readable text.
    /// </summary>
    public class Text : Property<string>
    {
        /// <summary>
        /// Initializes a new instance of the VText class.
        /// </summary>
        /// <param name="name">Property name</param>
        public Text(string name)
            : this(name, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the VText class.
        /// </summary>
        /// <param name="name">Property name</param>
        /// <param name="value">Property value</param>
        public Text(string name, string value)
            : base(name, value)
        {
            this.Parameters.Add("LANGUAGE", CultureInfo.CurrentCulture.Name);
        }

        /// <summary>
        /// Gets or sets the language of this property.
        /// </summary>
        public CultureInfo Language
        {
            get { return new CultureInfo(this.GetParameter("LANGUAGE")); }
            set { this.SetParameter("LANGUAGE", value); }
        }

        /// <summary>
        /// Implicitly converts a Text object to a string.
        /// </summary>
        /// <param name="text">Text object to convert</param>
        /// <returns>The string value of the Text object.</returns>
        public static implicit operator string(Text text)
        {
            if (text == null)
            {
                return null;
            }
            else
            {
                return text.Value;
            }
        }
    }
}
