//-----------------------------------------------------------------------
// <copyright file="VBase.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Globalization;
    using Versit.Core.Properties;

    /// <summary>
    /// Base class for all Versit objects.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         This class provides all base functionality required for basic Versit implementation. At
    ///         core it provides several collections of <see cref="Versit.Core.IProperty"/> objects
    ///         which provide backing fields for the public properties, as well as some shared Versit
    ///         properties such as <c>ClassificationType</c>, <c>Revision</c> and a <c>UniqueIdentifier</c>.
    ///     </para>
    ///     <para>
    ///         The property <c>ObjectType</c> denotes what type of Versit object we are dealing with.
    ///         The protected constructor takes this as an argument, and it is intended that all derived
    ///         classes call this constructor within their own, e.g.:
    ///     </para>
    ///     <code language="c#">
    ///         public class MyVersitObject : VBase
    ///         {
    ///             public MyVersitObject(// my parameters here)
    ///                 : base(ObjectType.MYOBJECTTYPE)
    ///             {
    ///                 // additional constructor logic here
    ///             }
    ///         }
    ///     </code>
    /// </remarks>
    /// <seealso cref="Versit.Core.IVersitObject"/>
    [Serializable]
    public abstract class VersitBase : IVersitObject
    {
        /// <summary>
        /// String key for the "base" <c>VPropertyCollection</c> used to 
        /// power the <c>Fields</c> property.
        /// </summary>
        public const string BaseFieldCollectionKey = "BASE";

        /// <summary>
        /// String key for the extended property collection.
        /// </summary>
        public const string ExtendedFieldCollectionKey = "X-PROP";

        /// <summary>
        /// Defines the standard array delimiter character string.
        /// </summary>
        public const string ArrayDelimiter = ";";

        /// <summary>
        /// Defines the standard format (ISO 8601) for DateTime
        /// values when written to string.
        /// </summary>
        public const string DateTimeFormat = "o";

        /// <summary>
        /// Initializes a new instance of the VBase class.
        /// </summary>
        /// <param name="type">Versit object type</param>
        /// <remarks>
        /// Any inheriting classes should make sure to call this constructor
        /// within their own constructor methods; otherwise, the classes will
        /// have to initialise all of the below themselves.
        /// </remarks>
        protected VersitBase(VersitObjectType type)
        {
            // initialise basic defaults
            this.Version = "2.1";
            this.Type = type;
            this.InnerElements = new Dictionary<VersitObjectType, VersitObjectCollection>();

            // initialise the field collections
            this.FieldCollections = new Dictionary<string, PropertyCollection>();
            this.FieldCollections.Add(BaseFieldCollectionKey, new PropertyCollection());
            this.FieldCollections.Add(ExtendedFieldCollectionKey, new PropertyCollection());

            // initialise default field values
            this.Fields.Add(new Property<ClassificationType>("CLASS", ClassificationType.PUBLIC));
            this.Fields.Add(new Property<string[]>("CATEGORIES", new string[] { }));
            this.Fields.Add(new Property<Guid>("UID", Guid.Empty));
            this.Fields.Add(new Property<DateTime>("REV", DateTime.UtcNow));
        }

        /// <summary>
        /// Gets the version of the specification this object uses.
        /// </summary>
        public string Version
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the type of this object.
        /// </summary>
        public VersitObjectType Type
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets or sets the last revision date of this object.
        /// </summary>
        public DateTime Revision
        {
            get { return GetPropertyValue<DateTime>("REV"); }
            set { SetPropertyValue<DateTime>("REV", value); }
        }

        /// <summary>
        /// Gets or sets the <c>ClassType</c> of this object.
        /// </summary>
        public ClassificationType Class
        {
            get { return GetPropertyValue<ClassificationType>("CLASS"); }
            set { SetPropertyValue<ClassificationType>("CLASS", value); }
        }

        /// <summary>
        /// Gets or sets a persistent, globally unique identifier associated with the object.
        /// </summary>
        public Guid UniqueIdentifier
        {
            get { return GetPropertyValue<Guid>("UID"); }
            set { SetPropertyValue<Guid>("UID", value); }
        }

        /// <summary>
        /// Gets a collection of extended <c>IVProperty</c> fields.
        /// </summary>
        public PropertyCollection ExtendedProperties
        {
            get { return this.FieldCollections[ExtendedFieldCollectionKey]; }
        }

        /// <summary>
        /// Gets or sets the categories for the vCalendar entity.
        /// </summary>
        public IEnumerable<string> Categories
        {
            get { return GetPropertyValue<string[]>("CATEGORIES"); }
            set { SetPropertyValue<string[]>("CATEGORIES", value.ToArray()); }
        }

        /// <summary>
        /// Gets a dictionary of nested versit objects.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         This is intended to be exposed using public properties by returning
        ///         a single collection from within this dictionary; for example, when
        ///         implementing a <c>VEvent</c>:
        ///     </para>
        ///     <code>
        ///         public VPropertyCollection Alarms
        ///         {
        ///             get
        ///             {
        ///                 return this.InnerElements[ObjectType.VALARM];
        ///             }
        ///         }
        ///     </code>
        /// </remarks>
        protected Dictionary<VersitObjectType, VersitObjectCollection> InnerElements
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a collection of inner field collections.
        /// </summary>
        /// <remarks>
        /// By default this will contain one inner collection called
        /// "BASE", which will hold all main properties. Note that this
        /// property is set in the <c>Initialise()</c> method.
        /// </remarks>
        protected Dictionary<string, PropertyCollection> FieldCollections
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a collection of <c>IVProperty</c> fields.
        /// </summary>
        /// <exception cref="System.ArgumentNullException">Value of Fields cannot be null</exception>
        protected PropertyCollection Fields
        {
            get { return this.FieldCollections[BaseFieldCollectionKey]; }
        }

        /// <summary>
        /// Exports this object to an instance of an exporter.
        /// </summary>
        /// <param name="exporter">Exporter object</param>
        public virtual void Export(IExporter exporter)
        {
            // TODO: asses whether this is sufficient

            exporter.WriteBeginTag(this);

            // export all fields in all field groups
            foreach (var coll in this.FieldCollections)
            {
                foreach (var field in coll.Value)
                {
                    exporter.WriteProperty(field);
                }
            }

            // export all inner elements
            foreach (var elements in this.InnerElements.Select(e => e.Value))
            {
                foreach (var element in elements)
                {
                    element.Export(exporter);
                }
            }

            exporter.WriteEndTag(this);
        }

        /// <summary>
        /// Sets an internal field value.
        /// </summary>
        /// <typeparam name="T">Type of field value</typeparam>
        /// <param name="name">Name of the field</param>
        /// <param name="value">New value of the field</param>
        /// <exception cref="System.InvalidOperationException">Field collection is null; you should call Initialise() first</exception>
        /// <exception cref="System.InvalidCastException">Type of this field does not match the given value type</exception>
        protected void SetPropertyValue<T>(string name, T value)
        {
            if (this.Fields == null)
            {
                throw new InvalidOperationException(Resources.Exception_FieldCollectionIsNull);
            }

            if (!this.Fields.Contains(name))
            {
                this.Fields.Add(new Property<T>(name, value));
            }
            else
            {
                var field = this.Fields[name];

                if (!field.MatchesType(typeof(T)))
                {
                    throw new InvalidCastException(Resources.Exception_FieldTypeMismatch);
                }

                (field as Property<T>).Value = value;
            }
        }

        /// <summary>
        /// Returns the value of a given field.
        /// </summary>
        /// <typeparam name="T">Type of field value</typeparam>
        /// <param name="name">Name of the field</param>
        /// <returns>Value of the field, or <c>default(T)</c> if not found</returns>
        /// <exception cref="System.InvalidOperationException">Field collection is null; you should call Initialise() first</exception>
        /// <exception cref="System.InvalidCastException">Type of this field does not match the given value type</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter",
            Justification = "I don't agree with this rule")]
        protected T GetPropertyValue<T>(string name)
        {
            if (this.Fields == null)
            {
                throw new InvalidOperationException(Resources.Exception_FieldCollectionIsNull);
            }

            if (!this.Fields.Contains(name))
            {
                return default(T);
            }

            var field = this.Fields[name];

            if (!field.MatchesType(typeof(T)))
            {
                throw new InvalidCastException(Resources.Exception_FieldTypeMismatch);
            }

            return (field as Property<T>).Value;
        }

        /// <summary>
        /// Gets a field.
        /// </summary>
        /// <typeparam name="T">Type of field to set</typeparam>
        /// <param name="name">Name of field to set</param>
        /// <returns>A <c>IVProperty</c> object</returns>
        /// <exception cref="System.InvalidOperationException">Field collection is null; you should call Initialise() first</exception>
        /// <exception cref="System.InvalidCastException">Type of this field does not match <typeparamref name="T"/></exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter",
            Justification = "I don't agree with this rule")]
        protected T GetProperty<T>(string name) where T : IProperty
        {
            if (this.Fields == null)
            {
                throw new InvalidOperationException(Resources.Exception_FieldCollectionIsNull);
            }

            if (!this.Fields.Contains(name))
            {
                return default(T);
            }

            var field = this.Fields[name];

            if (!(field is T))
            {
                throw new InvalidCastException(
                    string.Format(CultureInfo.CurrentCulture, Resources.Exception_FieldTypeMismatchWith, typeof(T).ToString()));
            }

            return (T)field;
        }

        /// <summary>
        /// Sets a field.
        /// </summary>
        /// <param name="name">Name of the field</param>
        /// <param name="value">Object to set</param>
        /// <remarks>If the field does not exist in the <c>Fields</c> collection,
        /// it will be added.</remarks>
        protected void SetProperty(string name, IProperty value)
        {
            if (!this.Fields.Contains(name))
            {
                this.Fields.Add(value);
            }
            else
            {
                this.Fields[name].CopyFrom(value);
            }
        }
    }
}
