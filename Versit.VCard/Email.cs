//-----------------------------------------------------------------------
// <copyright file="Email.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.VCard
{
    using Versit.Core;

    /// <summary>
    /// Represents an email address.
    /// </summary>
    public class Email : Property<string>
    {
        /// <summary>
        /// Initializes a new instance of the Email class.
        /// </summary>
        /// <param name="value">Email address</param>
        public Email(string value)
            : base("EMAIL", value)
        {
            this.EmailType = EmailType.INTERNET;
        }

        /// <summary>
        /// Gets or sets the type of this email address.
        /// </summary>
        public EmailType EmailType
        {
            get { return GetEnumParameter<EmailType>("TYPE"); }
            set { this.Parameters["TYPE"] = value.ToString(); }
        }
    }
}
