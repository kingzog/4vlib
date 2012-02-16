//-----------------------------------------------------------------------
// <copyright file="VName.cs" company="4verse">
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
    /// Represents a person's name in a <c>VContact</c> object.
    /// </summary>
    public class Name : Property<string[]>
    {
        /// <summary>
        /// Initializes a new instance of the VName class.
        /// </summary>
        public Name()
            : base("N", new string[5])
        {
        }

        /// <summary>
        /// Initializes a new instance of the VName class.
        /// </summary>
        /// <param name="firstName">First or given name</param>
        /// <param name="lastName">Last or family name</param>
        /// <returns>A new <c>VName</c> object</returns>
        public Name(string firstName, string lastName)
            : base("N", new string[5])
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        /// <summary>
        /// Gets or sets the person's surname.
        /// </summary>
        public string LastName
        {
            get { return this.Value[0]; }
            set { this.Value[0] = value; }
        }

        /// <summary>
        /// Gets or sets the person's first or given name.
        /// </summary>
        public string FirstName
        {
            get { return this.Value[1]; }
            set { this.Value[1] = value; }
        }

        /// <summary>
        /// Gets or sets this person's middle name(s).
        /// </summary>
        public string MiddleName
        {
            get { return this.Value[2]; }
            set { this.Value[2] = value; }
        }

        /// <summary>
        /// Gets or sets this person's title.
        /// </summary>
        /// <example>Mr, Mrs, Dr</example>
        public string Title
        {
            get { return this.Value[3]; }
            set { this.Value[3] = value; }
        }

        /// <summary>
        /// Gets or sets the person's suffix(es), if required.
        /// </summary>
        /// <example>MA, OBE, PhD</example>
        public string Suffix
        {
            get { return this.Value[4]; }
            set { this.Value[4] = value; }
        }

        /// <summary>
        /// Converts a string to a <c>VName</c>.
        /// </summary>
        /// <param name="name">Name to import (must be "FirstName LastName")</param>
        /// <returns>A <c>VName</c></returns>
        /// <example>
        ///     <code>VName name = "Keith Williams";</code>
        /// </example>
        public static implicit operator Name(string name)
        {
            var names = name.Split(' ');

            if (names.Length == 1)
            {
                return new Name(names[0], string.Empty);
            }
            else
            {
                return new Name(names[0], names[1]);
            }
        }

        /// <summary>
        /// Returns a formatted name string.
        /// </summary>
        /// <param name="format">Format to return name in</param>
        /// <returns>A formatted name string</returns>
        public string ToString(CommonNameFormat format)
        {
            var sb = new StringBuilder();

            switch (format)
            {
                case CommonNameFormat.LastFirst:
                    
                    sb.AppendFormat("{0}, ", this.LastName);
                    
                    if (!string.IsNullOrEmpty(this.Title))
                    {
                        sb.AppendFormat("{0} ", this.Title);
                    }

                    sb.AppendFormat("{0} ", this.FirstName);

                    if (!string.IsNullOrEmpty(this.MiddleName))
                    {
                        sb.Append(this.MiddleName);
                    }

                    break;

                default:

                    if (!string.IsNullOrEmpty(this.Title))
                    {
                        sb.AppendFormat("{0} ", this.Title);
                    }

                    sb.AppendFormat("{0} ", this.FirstName);

                    if (!string.IsNullOrEmpty(this.MiddleName))
                    {
                        sb.AppendFormat("{0} ", this.MiddleName);
                    }

                    sb.Append(this.LastName);

                    break;
            }

            if (!string.IsNullOrEmpty(this.Suffix))
            {
                sb.AppendFormat(" ({0})", this.Suffix);
            }

            return sb.ToString();
        }
    }
}
