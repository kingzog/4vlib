//-----------------------------------------------------------------------
// <copyright file="Duration.cs" company="4verse">
//     Copyright (C) 4verse. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Versit.Core
{
    using System;
    using System.Globalization;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Represents a duration of time.
    /// </summary>
    public struct Duration : IComparable, IEquatable<Duration>
    {
        /// <summary>
        /// Regular expression which describes the string representation
        /// of a Duration.
        /// </summary>
        private const string DurationRegularExpression = @"[\+|\-]?(P([0-9]*[W|D])*)|(T([0-9]*[H|M|S])*)";

        /// <summary>
        /// Gets the timespan represented by this duration.
        /// </summary>
        private TimeSpan span;

        /// <summary>
        /// Initializes a new instance of the Duration struct.
        /// </summary>
        /// <param name="span">TimeSpan of the duration</param>
        public Duration(TimeSpan span)
        {
            this.span = span;
        }

        /// <summary>
        /// Initializes a new instance of the Duration struct.
        /// </summary>
        /// <param name="hours">Number of hours</param>
        /// <param name="minutes">Number of minutes</param>
        /// <param name="seconds">Number of seconds</param>
        public Duration(int hours, int minutes, int seconds)
            : this(new TimeSpan(hours, minutes, seconds))
        {
        }

        /// <summary>
        /// Initializes a new instance of the Duration struct.
        /// </summary>
        /// <param name="days">Number of days</param>
        /// <param name="hours">Number of hours</param>
        /// <param name="minutes">Number of minutes</param>
        /// <param name="seconds">Number of seconds</param>
        public Duration(int days, int hours, int minutes, int seconds)
            : this(new TimeSpan(days, hours, minutes, seconds))
        {
        }

        /// <summary>
        /// Gets the inner TimeSpan of this Duration.
        /// </summary>
        public TimeSpan Span
        {
            get { return this.span; }
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
        public static bool TryParse(string input, out Duration output)
        {
            output = new Duration();

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

                output = new Duration(span);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Converts a TimeSpan to a Duration.
        /// </summary>
        /// <param name="span">TimeSpan to convert</param>
        /// <returns>A Duration struct</returns>
        public static implicit operator Duration(TimeSpan span)
        {
            return new Duration(span);
        }

        /// <summary>
        /// Converts a Duration to a TimeSpan.
        /// </summary>
        /// <param name="duration">Duration to convert</param>
        /// <returns>A TimeSpan struct</returns>
        public static explicit operator TimeSpan(Duration duration)
        {
            return duration.span;
        }

        /// <summary>
        /// Indicates whether two Duration instances are equal.
        /// </summary>
        /// <param name="duration1">First Duration</param>
        /// <param name="duration2">Second Duration</param>
        /// <returns>True if equal</returns>
        public static bool operator ==(Duration duration1, Duration duration2)
        {
            return duration1.span == duration2.span;
        }

        /// <summary>
        /// Indicates whether two Duration instances are not equal.
        /// </summary>
        /// <param name="duration1">First Duration</param>
        /// <param name="duration2">Second Duration</param>
        /// <returns>True if not equal</returns>
        public static bool operator !=(Duration duration1, Duration duration2)
        {
            return duration1.span != duration2.span;
        }

        /// <summary>
        /// Indicates whether one duration is less than another.
        /// </summary>
        /// <param name="duration1">First Duration</param>
        /// <param name="duration2">Second Duration</param>
        /// <returns>True if not equal</returns>
        /// <returns>True if not second duration is less than the first</returns>
        public static bool operator <(Duration duration1, Duration duration2)
        {
            return duration1.span < duration2.Span;
        }

        /// <summary>
        /// Indicates whether one duration is greater than another.
        /// </summary>
        /// <param name="duration1">First Duration</param>
        /// <param name="duration2">Second Duration</param>
        /// <returns>True if not second duration is greater than to the first</returns>
        public static bool operator >(Duration duration1, Duration duration2)
        {
            return duration1.span > duration2.Span;
        }

        /// <summary>
        /// Indicates whether one duration is less than or equal to another.
        /// </summary>
        /// <param name="duration1">First Duration</param>
        /// <param name="duration2">Second Duration</param>
        /// <returns>True if not second duration is less than or equal to the first</returns>
        public static bool operator <=(Duration duration1, Duration duration2)
        {
            return duration1.span <= duration2.Span;
        }

        /// <summary>
        /// Indicates whether one duration is greater than or equal to another.
        /// </summary>
        /// <param name="duration1">First Duration</param>
        /// <param name="duration2">Second Duration</param>
        /// <returns>True if not second duration is greater than or equal to the first</returns>
        public static bool operator >=(Duration duration1, Duration duration2)
        {
            return duration1.span >= duration2.Span;
        }

        /// <summary>
        /// Returns a formatted duration string.
        /// </summary>
        /// <returns>A formatted duration string</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append((this.span.TotalSeconds > 0) ? "+P" : "-P");

            var span2 = this.span.TotalSeconds > 0 ? this.span : this.span.Negate();

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

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>True if equal</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Indicates whether this instance is equal to a specified Duration object.
        /// </summary>
        /// <param name="other">Duration object to compare</param>
        /// <returns>True if equal</returns>
        public bool Equals(Duration other)
        {
            return this.GetHashCode() == other.GetHashCode();
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A hash code</returns>
        public override int GetHashCode()
        {
            return this.span.GetHashCode();
        }

        /// <summary>
        /// Compares the value of this instance to a specified Duration value
        /// and returns an integer that indicates whether this instance is 
        /// longer than, the same as, or shorter than the specified Duration value.
        /// </summary>
        /// <param name="value">A Duration object to compare</param>
        /// <returns>
        /// A signed number indicating the relative values of this instance and value.
        /// Value Description A negative integer This instance is shorter than value.
        /// Zero This instance is equal to value. A positive integer This instance is
        /// longer than value.
        /// </returns>
        public int CompareTo(Duration value)
        {
            return this.Span.CompareTo(value.Span);
        }

        /// <summary>
        /// Compares the value of this instance to a specified object value
        /// and returns an integer that indicates whether this instance is 
        /// longer than, the same as, or shorter than the specified Duration value.
        /// </summary>
        /// <param name="obj">An object to compare, or null</param>
        /// <returns>
        /// A signed number indicating the relative values of this instance and value.
        /// Value Description A negative integer This instance is shorter than value.
        /// Zero This instance is equal to value. A positive integer This instance is
        /// longer than value.
        /// </returns>
        /// <exception cref="System.ArgumentException">Value is not a Duration</exception>
        public int CompareTo(object obj)
        {
            if (obj is Duration)
            {
                return this.CompareTo((Duration)obj);
            }
            else
            {
                throw new ArgumentException("Value is not a Duration", "obj");
            }
        }
    }
}
