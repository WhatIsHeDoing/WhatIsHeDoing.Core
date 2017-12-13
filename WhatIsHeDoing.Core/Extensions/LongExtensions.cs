namespace WhatIsHeDoing.Core.Extensions
{
    using System;

    /// <summary>
    /// Provides extension methods for the long value type.
    /// </summary>
    public static class LongExtensions
    {
        /// <summary>
        /// Determines the length of a positive number.
        /// </summary>
        /// <param name="value">To test</param>
        /// <returns>Length</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown for the <see cref="long.MinValue">minimum value</see>
        /// </exception>
        public static long Length(this long value)
        {
            if (value <= long.MinValue)
            {
                throw new ArgumentOutOfRangeException("value");
            }

            if (value < 0)
            {
                value = -value;
            }

            return (value == 0) ? 1 :
                (long)Math.Floor(Math.Log10(value)) + 1;
        }

        /// <summary>
        /// Strips a specified number of digits from a number.
        /// If the number of digits to strip
        /// exceeds the length of the number, will return zero.
        /// </summary>
        /// <example>123.StripDigits(2) == 1</example>
        /// <param name="value">To strip</param>
        /// <param name="numberToStrip">Number of digits to remove</param>
        /// <returns>Number</returns>
        public static long StripDigits(this long value, int numberToStrip)
        {
            var mask = (long)Math.Pow(10, numberToStrip);
            return (value - (value % mask)) / mask;
        }
    }
}
