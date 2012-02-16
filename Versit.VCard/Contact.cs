//-----------------------------------------------------------------------
// <copyright file="VContact.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.VCard
{
    using System;
    using Versit.Core;

    /// <summary>
    /// Represents a person or organisation's contact details.
    /// </summary>
    public class Contact : VersitBase
    {
        /// <summary>
        /// Defines the key for the address field collection.
        /// </summary>
        private const string AddressFieldsKey = "ADDRESS";

        /// <summary>
        /// Defines the key for the telephone field collection.
        /// </summary>
        private const string TelephoneFieldsKey = "TELEPHONE";

        /// <summary>
        /// Defines the key for the email field collection.
        /// </summary>
        private const string EmailFieldsKey = "EMAIL";

        /// <summary>
        /// Initializes a new instance of the VContact class.
        /// </summary>
        public Contact()
            : base(VersitObjectType.VCARD)
        {
            this.Fields.Add(new Name { Name = "N" });

            this.Fields.Add(new Property<string>("FN", string.Empty));
            this.Fields.Add(new Property<string>("ORG", string.Empty));
            this.Fields.Add(new Property<string>("TITLE", string.Empty));
            this.Fields.Add(new Property<string>("ROLE", string.Empty));
            this.Fields.Add(new Property<DateTime?>("BDAY", null));
            this.Fields.Add(new Property<Uri>("URL", null));
            this.Fields.Add(new Text("NOTE", string.Empty));

            this.FieldCollections.Add(AddressFieldsKey, new VPropertyCollection<Address>());
            this.FieldCollections.Add(TelephoneFieldsKey, new VPropertyCollection<Telephone>());
            this.FieldCollections.Add(EmailFieldsKey, new VPropertyCollection<Email>());
        }

        /// <summary>
        /// Gets or sets this contact's name.
        /// </summary>
        /// <example>Jake Smith</example>
        public Name Name
        {
            get { return GetProperty<Name>("N"); }
            set { SetProperty("N", value); }
        }

        /// <summary>
        /// Gets or sets the formatted name of this contact.
        /// </summary>
        /// <example>Mr. Jake Smith</example>
        public string FormattedName
        {
            get { return GetPropertyValue<string>("FN"); }
            set { SetPropertyValue<string>("FN", value); }
        }

        /// <summary>
        /// Gets or sets the job title of this contact.
        /// </summary>
        /// <example>Software Developer</example>
        public string Title
        {
            get { return GetPropertyValue<string>("TITLE"); }
            set { SetPropertyValue<string>("TITLE", value); }
        }

        /// <summary>
        /// Gets or sets the role, occupation, or business category of 
        /// the contact within an organization.
        /// </summary>
        /// <example>Executive</example>
        public string Role
        {
            get { return GetPropertyValue<string>("ROLE"); }
            set { SetPropertyValue<string>("ROLE", value); }
        }

        /// <summary>
        /// Gets or sets the name of the organisation this contact
        /// works for.
        /// </summary>
        /// <remarks>
        /// Use a semi-colon to include organisation unit information,
        /// e.g. ABC Corp;Marketing Division.
        /// </remarks>
        public string Organization
        {
            get { return GetPropertyValue<string>("ORG"); }
            set { SetPropertyValue<string>("ORG", value); }
        }

        /// <summary>
        /// Gets or sets this contact's birthday.
        /// </summary>
        public DateTime? Birthday
        {
            get { return GetPropertyValue<DateTime?>("BDAY"); }
            set { SetPropertyValue<DateTime?>("BDAY", value); }
        }

        /// <summary>
        /// Gets or sets a URL associated with this contact.
        /// </summary>
        /// <remarks>
        /// For instance, the person or company's website.
        /// </remarks>
        public Uri Url
        {
            get { return GetPropertyValue<Uri>("URL"); }
            set { SetPropertyValue<Uri>("URL", value); }
        }

        /// <summary>
        /// Gets a collection of addresses for this contact.
        /// </summary>
        public VPropertyCollection<Address> Addresses
        {
            get { return (VPropertyCollection<Address>)this.FieldCollections[AddressFieldsKey]; }
        }

        /// <summary>
        /// Gets this contact's delivery address.
        /// </summary>
        public VPropertyCollection<Telephone> TelephoneNumbers
        {
            get { return (VPropertyCollection<Telephone>)this.FieldCollections[TelephoneFieldsKey]; }
        }

        /// <summary>
        /// Gets this contact's delivery address.
        /// </summary>
        public VPropertyCollection<Email> EmailAddresses
        {
            get { return (VPropertyCollection<Email>)this.FieldCollections[EmailFieldsKey]; }
        }

        /// <summary>
        /// Gets or sets a photo associated with this contact.
        /// </summary>
        public Image Photo
        {
            get { return GetProperty<Image>("PHOTO"); }
            set { SetProperty("PHOTO", value); }
        }

        /// <summary>
        /// Gets or sets a logo associated with this contact
        /// (usually for organisations).
        /// </summary>
        public Image Logo
        {
            get { return GetProperty<Image>("LOGO"); }
            set { SetProperty("LOGO", value); }
        }

        /// <summary>
        /// Gets or sets any further comments relating to this contact.
        /// </summary>
        public Text Note
        {
            get { return GetProperty<Text>("NOTE"); }
            set { SetProperty("NOTE", value); }
        }
    }
}
