namespace WhatIsHeDoing.Core.Extensions
{
    using System;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Provides extension methods for string.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Formats a string as a currency from the current globalisation.
        /// </summary>
        /// <param name="source">To parse</param>
        /// <returns>Formatted string or original if not a decimal</returns>
        public static string AsCurrency(this string source) =>
            string.IsNullOrWhiteSpace(source)
            ? source
            : decimal.TryParse(
                source,
                NumberStyles.Number,
                CultureInfo.CurrentCulture,
                out decimal result)
                    ? Math.Round(result, 2).ToString() : source;

        /// <summary>
        /// Determines whether this string can be converted
        /// to a boolean and that value is true.
        /// </summary>
        /// <param name="value">To test</param>
        /// <returns>
        /// <c>true</c> if the value is a boolean and true, or <c>false</c>
        /// </returns>
        public static bool IsTrue(this string value) =>
            bool.TryParse(value, out bool result) && result;

        /// <summary>
        /// Invoke a Parse method from the TResult type on the value.
        /// </summary>
        /// <typeparam name="TResult">Containing the parse method</typeparam>
        /// <param name="value">To parse</param>
        /// <returns>Parsed value</returns>
        /// <exception cref="TypeLoadException">
        /// Thrown if TResult does not have a Parse method.
        /// </exception>
        public static TResult Parse<TResult>(this string value) =>
            value.TryParse(out TResult result)
                ? result
                : throw new TypeLoadException("Cannot find Parse method");

        /// <summary>
        /// Converts a string representation of a byte array
        /// - comma-separated values - to an actual byte array.
        /// </summary>
        /// <remarks>Leaves the underlying code to throw on error!</remarks>
        /// <param name="source">To convert</param>
        /// <returns>Bytes</returns>
        public static byte[] ToBytes(this string source) =>
            !string.IsNullOrWhiteSpace(source)
            ? source
                .Split(',')
                .Select(c => Convert.ToByte(c))
                .ToArray()
            : throw new ArgumentNullException(nameof(source));

        /// <summary>
        /// Tries to invoke a Parse method from the TResult type on the value.
        /// </summary>
        /// <typeparam name="TResult">Containing the parse method</typeparam>
        /// <param name="value">To parse</param>
        /// <param name="result">Parsed value or default on failure</param>
        /// <returns>Success</returns>
        public static bool TryParse<TResult>(this string value, out TResult result)
        {
            var methodInfo = typeof(TResult).GetMethod(
                "Parse", new Type[] { typeof(string) });

            if (methodInfo == null)
            {
                result = default(TResult);
                return false;
            }

            result = (TResult)methodInfo.Invoke(null, new object[] { value });
            return true;
        }
    }
}
