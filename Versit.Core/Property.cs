//-----------------------------------------------------------------------
// <copyright file="VProperty.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Versit.Core.Properties;

    /// <summary>
    /// A property is the definition of an individual attribute describing an
    /// associated <c>IVObject</c>.
    /// </summary>
    /// <typeparam name="T">Type of value this property holds</typeparam>
    [Serializable()]
    public class Property<T> : IProperty
    {
        /// <summary>
        /// Initializes a new instance of the VProperty class.
        /// </summary>
        /// <param name="name">Property name</param>
        /// <param name="value">Property value</param>
        /// <exception cref="System.ArgumentNullException">Name parameter cannot be null on a VProperty</exception>
        public Property(string name, T value)
            : base()
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", Resources.Exception_NullPropertyName);
            }

            this.Name = name.ToUpper(CultureInfo.CurrentCulture);
            this.Value = value;

            this.Parameters = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets the name of this property.
        /// </summary>
        /// <example>FN, ORG, ADR</example>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value of this property.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Gets the named parameters, if any, of this property.
        /// </summary>
        public Dictionary<string, string> Parameters { get; private set; }

        /// <summary>
        /// Gets or sets the encoding used in this property.
        /// </summary>
        /// <remarks>Note that if this is not explicitly set, it will
        /// always return <c>EncodingType.QUOTEDPRINTABLE</c>, and
        /// will not be output when saving a VFile.</remarks>
        public EncodingType Encoding
        {
            get { return GetEnumParameter<EncodingType>("ENCODING"); }
            set { this.SetParameter("ENCODING", value); }
        }

        /// <summary>
        /// Implicitly converts this property to its value type.
        /// </summary>
        /// <param name="property">Property to convert</param>
        /// <returns>An object of <typeparamref name="T"/></returns>
        public static implicit operator T(Property<T> property)
        {
            return property.Value;
        }

        /// <summary>
        /// Returns the type of the value of this property.
        /// </summary>
        /// <returns>The type of Value</returns>
        public Type ValueType()
        {
            return typeof(T);
        }

        /// <summary>
        /// Gets a string representation of this property's value.
        /// </summary>
        /// <returns>A System.String object</returns>
        public virtual string ValueToString()
        {
            if (this.Value == null ||
                string.IsNullOrEmpty(this.Value.ToString()))
            {
                // empty properties aren't output
                return string.Empty;
            }

            if (this.Value is Array || this.Value is Enumerable)
            {
                // TODO: rewrite with string.Join
                //// return string.Join(Exporter.ArrayDelimiter, this.Value as Array);

                /* Treat arrays or enumerable properties slightly
                 * differently; we need to output them as sem-colon
                 * -delineated strings. This is used in several 
                 * standard properties, e.g. VAddress, which is 
                 * stored as a string array.
                 * */

                var sb = new StringBuilder();

                foreach (var item in this.Value as Array)
                {
                    if (item != null)
                    {
                        sb.Append(item.ToString());
                    }

                    sb.Append(VersitBase.ArrayDelimiter);
                }

                var valueString = sb.ToString();

                // trim the trailing delimiter string
                if (valueString.EndsWith(VersitBase.ArrayDelimiter, StringComparison.CurrentCulture))
                {
                    /* note: we're not using TrimEnd, because we only want
                     * to remove the LAST delimiter, not all of the trailing
                     * ones; it's fine to have empty delimiters to denote
                     * empty properties in our final string.
                     * */

                    valueString = valueString.Substring(0, valueString.Length - VersitBase.ArrayDelimiter.Length);
                }
                
                return valueString;
            }
            else
            {
                if (this.Value.GetType() == typeof(DateTime))
                {
                    DateTime date = (DateTime)Convert.ChangeType(this.Value, typeof(DateTime), CultureInfo.CurrentCulture);
                    return date.ToString(VersitBase.DateTimeFormat, CultureInfo.CurrentCulture);
                }

                if (this.Value.GetType() == typeof(DateTime?))
                {
                    /* TODO: this could be done more elegantly,
                     * maybe fetching the nullable base value
                     * and then using that (discarding if null).
                     * */

                    DateTime? date = (DateTime?)Convert.ChangeType(this.Value, typeof(DateTime), CultureInfo.CurrentCulture);
                    return date.Value.ToString(VersitBase.DateTimeFormat, CultureInfo.CurrentCulture);
                }
                else
                {
                    return this.Value.ToString();
                }
            }
        }

        /// <summary>
        /// Determines if the <c>Type</c> of this property's value matches
        /// a given type.
        /// </summary>
        /// <param name="type">Type to compare</param>
        /// <returns>True if the types match</returns>
        public bool MatchesType(Type type)
        {
            return type == this.ValueType();
        }

        /// <summary>
        /// Determines if this property has an empty value, and so should
        /// not be output when saving.
        /// </summary>
        /// <returns><c>True</c> if the property's value is empty.</returns>
        /// <remarks>
        /// Empty has a different definition depending on the property's
        /// <c>T</c> - it could be Guid.Empty, or string.Empty, or null.
        /// </remarks>
        public bool IsEmpty()
        {
            if (this.ValueType() == typeof(Guid))
            {
                return ((Guid)Convert.ChangeType(this.Value, typeof(Guid), CultureInfo.CurrentCulture)) == Guid.Empty;
            }
            
            if (this.ValueType() == typeof(Coordinates))
            {
                var value = ((Coordinates)Convert.ChangeType(this.Value, typeof(Coordinates), CultureInfo.CurrentCulture));
                return (value.Latitude * value.Longitude) == null;    // null value in either nullifies this struct
            }
            
            if (this.ValueType() == typeof(string))
            {
                return string.IsNullOrEmpty(this.Value.ToString());
            }
            
            if (this.Value is Array)
            {
                return (this.Value as Array).Length == 0;
            }

            if (this.Value is TimeSpan)
            {
                var value = ((TimeSpan)Convert.ChangeType(this.Value, typeof(TimeSpan), CultureInfo.CurrentCulture));
                return value.Ticks > 0;
            }

            return this.Value == null;
        }

        /// <summary>
        /// Gets a given parameter value as a string.
        /// </summary>
        /// <param name="name">Name of the parameter</param>
        /// <returns>A string value</returns>
        /// <exception cref="System.InvalidOperationException">Parameter collection is null!</exception>
        public string GetParameter(string name)
        {
            if (this.Parameters == null)
            {
                throw new InvalidOperationException(Resources.Exception_ParameterCollectionIsNull);
            }

            if (!this.Parameters.ContainsKey(name))
            {
                return string.Empty;
            }

            return this.Parameters[name];
        }

        /// <summary>
        /// Gets the value of a parameter as an enum.
        /// </summary>
        /// <typeparam name="TEnum">Type of enum to return</typeparam>
        /// <param name="name">Name of parameter</param>
        /// <returns>The value of the parameter as <typeparamref name="TEnum"/>, or <c>default(U)</c> if not found</returns>
        /// <exception cref="System.InvalidOperationException">U must be an Enum</exception>
        /// <exception cref="System.InvalidOperationException">Parameter collection is null!</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter",
            Justification = "I don't agree with this rule")]
        public TEnum GetEnumParameter<TEnum>(string name)
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new InvalidOperationException(Resources.Exception_TypeIsNotEnum);
            }

            if (this.Parameters == null)
            {
                throw new InvalidOperationException(Resources.Exception_ParameterCollectionIsNull);
            }

            if (!this.Parameters.ContainsKey(name))
            {
                return default(TEnum);
            }

            var stringValue = this.GetParameter(name);

            return (TEnum)Enum.Parse(typeof(TEnum), stringValue, true);
        }

        /// <summary>
        /// Sets the value of a given parameter.
        /// </summary>
        /// <param name="name">Name of the parameter</param>
        /// <param name="value">Value of the parameter to set</param>
        /// <exception cref="System.InvalidOperationException">Parameter collection is null!</exception>
        public void SetParameter(string name, object value)
        {
            if (this.Parameters == null)
            {
                throw new InvalidOperationException(Resources.Exception_ParameterCollectionIsNull);
            }

            if (!this.Parameters.ContainsKey(name))
            {
                this.Parameters.Add(name, value.ToString());
            }
            else
            {
                this.Parameters[name] = value.ToString();
            }
        }

        /// <summary>
        /// Copies the value and parameters from <paramref name="value"/> to
        /// this property.
        /// </summary>
        /// <param name="value">Property to copy from</param>
        /// <exception cref="System.ArgumentException">Cannot copy property value - the types of the source and destination property are different</exception>
        public void CopyFrom(IProperty value)
        {
            if (!value.MatchesType(typeof(T)))
            {
                throw new ArgumentException(Resources.Exception_CopyPropertyTypeMismatch, "value");
            }

            var target = (Property<T>)value;

            this.Value = (T)Convert.ChangeType(target.Value, typeof(T), CultureInfo.CurrentCulture);
            this.Parameters = target.Parameters;
        }

        /// <summary>
        /// Renders the value of this property to a string representation
        /// </summary>
        /// <returns>A string representation of this property's name and value</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append((this.Name ?? string.Empty).ToUpper(CultureInfo.CurrentCulture)); // molly-guard

            if (this.Parameters != null &&
                this.Parameters.Any())
            {
                foreach (var param in this.Parameters)
                {
                    if (string.IsNullOrEmpty(param.Value) ||
                        param.Value == "UNKNOWN")
                    {
                        /* ignore blank parameters, or enum parameters
                         * which have been set to (or left as) unknown;
                         * these are effectively NULL values.
                         * */

                        continue;
                    }

                    sb.Append(";");

                    if (!string.IsNullOrEmpty(param.Key) &&
                        param.Key != param.Value)
                    {
                        /* If the key is non-empty and not the same as the value,
                         * we can use a typical KEY=VALUE format (most params will
                         * use this format). It is supported in the Versit 
                         * specification to have VALUE;VALUE;VALUE params, e.g.
                         * TEL;WORK;FAX:01904691066, so we support that by using
                         * either blank keys or keys which match the value.
                         * */

                        sb.AppendFormat(CultureInfo.InvariantCulture, "{0}=", param.Key);
                    }

                    sb.Append(param.Value);
                }
            }

            sb.AppendFormat(CultureInfo.InvariantCulture, ":{0}", this.ValueToString());
            return sb.ToString();
        }
    }
}
