namespace WhatIsHeDoing.Core.Extensions
{
    using System;

    /// <summary>
    /// Provides extension methods for the integer value type.
    /// </summary>
    public static class IntegerExtensions
    {
        /// <summary>
        /// Rounds to the largest comparison number.
        /// </summary>
        /// <example><code>123.ToNearestCeiling(10) == 130</code></example>
        /// <param name="source">Number to round</param>
        /// <param name="nearest">Rounder</param>
        /// <returns>Rounded number</returns>
        public static int ToNearestCeiling(this int source, uint nearest)
            => ((int)Math.Ceiling(source / Convert.ToDouble(nearest))) * (int)nearest;
    }
}
