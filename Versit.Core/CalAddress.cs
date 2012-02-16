//-----------------------------------------------------------------------
// <copyright file="VCalAddress.cs" company="4verse">
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
    /// Base class for calendar addresses.
    /// </summary>
    public class CalAddress : Property<Uri>, IProperty
    {
        /// <summary>
        /// Initializes a new instance of the CalAddress class.
        /// </summary>
        /// <param name="name">Property name</param>
        public CalAddress(string name)
            : this(name, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the CalAddress class.
        /// </summary>
        /// <param name="name">Property name</param>
        /// <param name="value">URI of the calendar address</param>
        public CalAddress(string name, Uri value)
            : base(name, value)
        {
            this.Parameters.Add("CN", string.Empty);
            this.Parameters.Add("DIR", string.Empty);
            this.Parameters.Add("SENT-BY", string.Empty);
            this.Parameters.Add("LANGUAGE", string.Empty);
            this.Parameters.Add("MEMBER", string.Empty);
        }

        /// <summary>
        /// Gets or sets the common name.
        /// </summary>
        public string CommonName
        {
            get { return this.GetParameter("CN"); }
            set { this.SetParameter("CN", value); }
        }

        /// <summary>
        /// Gets or sets the directory path.
        /// </summary>
        public string DirectoryPath
        {
            get { return this.GetParameter("DIR"); }
            set { this.SetParameter("DIR", value); }
        }

        /// <summary>
        /// Gets or sets the sent by property.
        /// </summary>
        public string SentBy
        {
            get { return this.GetParameter("SENT-BY"); }
            set { this.SetParameter("SENT-BY", value); }
        }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        public string Language
        {
            get { return this.GetParameter("LANGUAGE"); }
            set { this.SetParameter("LANGUAGE", value); }
        }

        /// <summary>
        /// Gets or sets the member.
        /// </summary>
        public string Member
        {
            get { return this.GetParameter("MEMBER"); }
            set { this.SetParameter("MEMBER", value); }
        }

        /// <summary>
        /// Renders this address to string.
        /// </summary>
        /// <returns>The string value of the address</returns>
        public override string ToString()
        {
            // TODO: some special rules apply here
            // See http://www.kanzaki.com/docs/ical/member.html
            return base.ToString();
        }
    }
}
