using System;

namespace WhatIsHeDoing.Core.Extensions
{
    /// <summary>
    /// Provides extension methods for the unsigned long value type.
    /// </summary>
    public static class UnsignedLongExtensions
    {
        /// <summary>
        /// Determines the length of a number.
        /// </summary>
        /// <param name="value">To test</param>
        /// <returns>Length</returns>
        public static ulong Length(this ulong value) => value == 0
            ? 1
            : (ulong)Math.Floor(Math.Log10(value)) + 1;

        /// <summary>
        /// Strips a specified number of digits from a number.
        /// If the number of digits to strip
        /// exceeds the length of the number, will return zero.
        /// </summary>
        /// <example>123.StripDigits(2) == 1</example>
        /// <param name="value">To strip</param>
        /// <param name="numberToStrip">Number of digits to remove</param>
        /// <returns>Number</returns>
        public static ulong StripDigits(this ulong value, int numberToStrip)
        {
            var mask = (ulong)Math.Pow(10, numberToStrip);
            return (value - (value % mask)) / mask;
        }
    }
}
