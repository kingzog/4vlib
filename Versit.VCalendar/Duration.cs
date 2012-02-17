//-----------------------------------------------------------------------
// <copyright file="Duration.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.VCalendar
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using Versit.Core;

    /// <summary>
    /// A property containing a duration of time.
    /// </summary>
    public class Duration : Property<TimeSpan>
    {
        /// <summary>
        /// Regular expression which describes the string representation
        /// of a Duration.
        /// </summary>
        private const string DurationRegularExpression = @"[\+|\-]?(P([0-9]*[W|D])*)|(T([0-9]*[H|M|S])*)";

        /// <summary>
        /// Initializes a new instance of the Duration class.
        /// </summary>
        /// <param name="name">Property name</param>
        public Duration(string name)
            : this(name, new TimeSpan())
        {
        }

        /// <summary>
        /// Initializes a new instance of the Duration class.
        /// </summary>
        /// <param name="name">Property name</param>
        /// <param name="hours">Number of hours</param>
        /// <param name="minutes">Number of minutes</param>
        /// <param name="seconds">Number of seconds</param>
        public Duration(string name, int hours, int minutes, int seconds)
            : this(name, new TimeSpan(hours, minutes, seconds))
        {
        }

        /// <summary>
        /// Initializes a new instance of the Duration class.
        /// </summary>
        /// <param name="name">Property name</param>
        /// <param name="days">Number of days</param>
        /// <param name="hours">Number of hours</param>
        /// <param name="minutes">Number of minutes</param>
        /// <param name="seconds">Number of seconds</param>
        public Duration(string name, int days, int hours, int minutes, int seconds)
            : this(name, new TimeSpan(days, hours, minutes, seconds))
        {
        }

        /// <summary>
        /// Initializes a new instance of the Duration class.
        /// </summary>
        /// <param name="name">Property name</param>
        /// <param name="value">TimeSpan value</param>
        public Duration(string name, TimeSpan value)
            : base(name, value)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Duration class.
        /// </summary>
        /// <param name="name">Property name</param>
        /// <param name="value">String duration value</param>
        public Duration(string name, string value)
            : this(name, new TimeSpan())
        {
            TimeSpan span;

            if (Duration.TryParse(value, out span))
            {
                this.Value = span;
            }
            else
            {
                throw new ArgumentException("Invalid duration string value");
            }
        }

        /// <summary>
        /// Determines whether a given string is a valid string representation
        /// of a Duration object.
        /// </summary>
        /// <param name="input">String to test</param>
        /// <returns>True if the string is parsable</returns>
        public static bool IsValidString(string input)
        {
            return Regex.IsMatch(input, DurationRegularExpression, RegexOptions.CultureInvariant);
        }

        /// <summary>
        /// Tries to parse a duration object from its string representation.
        /// </summary>
        /// <param name="input">String to parse</param>
        /// <param name="output">Duration to output</param>
        /// <returns>True if the string is valid</returns>
        /// <remarks>Takes a lax approach to parsing, trying to parse as much
        /// of the string as possible and ignoring invalid portions.</remarks>
        public static bool TryParse(string input, out TimeSpan output)
        {
            output = new TimeSpan();

            if (IsValidString(input))
            {
                bool positive = !input.StartsWith("-", true, CultureInfo.CurrentCulture); // it's positive if it starts with "+" or no symbol
                var span = new TimeSpan();

                var spanParts = Regex.Matches(input, @"[0-9]*[W|D|H|M|S]", RegexOptions.CultureInvariant);

                foreach (Match match in spanParts)
                {
                    var partString = Regex.Match(match.Value, @"[W|D|H|M|S]", RegexOptions.CultureInvariant);
                    var numberString = Regex.Match(match.Value, @"[0-9]*", RegexOptions.CultureInvariant);
                    var number = int.Parse(numberString.Value, CultureInfo.CurrentCulture);

                    switch (partString.Value)
                    {
                        case "W":
                            span = span.Add(new TimeSpan(number * 7, 0, 0, 0));
                            break;
                        case "D":
                            span = span.Add(new TimeSpan(number, 0, 0, 0));
                            break;
                        case "H":
                            span = span.Add(new TimeSpan(0, number, 0, 0));
                            break;
                        case "M":
                            span = span.Add(new TimeSpan(0, 0, number, 0));
                            break;
                        case "S":
                            span = span.Add(new TimeSpan(0, 0, 0, number));
                            break;
                        default:
                            break;
                    }
                }

                if (!positive)
                {
                    span.Negate();
                }

                output = span;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets a string representation of this duration.
        /// </summary>
        /// <returns>A System.String object</returns>
        public override string ValueToString()
        {
            var sb = new StringBuilder();
            var span = this.Value;

            sb.Append((span.TotalSeconds > 0) ? "+P" : "-P");

            var span2 = span.TotalSeconds > 0 ? span : span.Negate();

            if (span2.Days > 0)
            {
                if (span2.TotalDays % 7 == 0)
                {
                    sb.AppendFormat("{0}W", span2.TotalDays / 7);
                }
                else
                {
                    sb.AppendFormat("{0}D", span2.Days);
                }
            }

            if (span2.Seconds > 0 ||
                span2.Minutes > 0 ||
                span2.Hours > 0)
            {
                sb.Append("T");

                if (span2.Hours > 0)
                {
                    sb.AppendFormat("{0}H", span2.Hours);
                }

                if (span2.Minutes > 0)
                {
                    sb.AppendFormat("{0}M", span2.Minutes);
                }

                if (span2.Seconds > 0)
                {
                    sb.AppendFormat("{0}S", span2.Seconds);
                }
            }

            return sb.ToString();
        }
    }
}
