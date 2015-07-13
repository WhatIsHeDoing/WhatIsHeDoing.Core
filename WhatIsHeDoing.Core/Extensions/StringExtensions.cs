using System;
using System.Reflection;

namespace WhatIsHeDoing.Core.Extensions
{
    /// <summary>
    /// Provides extension methods for string.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Invoke a Parse method from the TResult type on the value.
        /// </summary>
        /// <typeparam name="TResult">Containing the parse method</typeparam>
        /// <param name="value">To parse</param>
        /// <returns>Parsed value</returns>
        /// <exception cref="TypeLoadException">
        /// Thrown if TResult does not have a Parse method.
        /// </exception>
        public static TResult Parse<TResult>(this string value)
        {
            TResult result;
            
            if (!value.TryParse<TResult>(out result))
            {
                throw new TypeLoadException("Cannot find Parse method");
            }

            return result;
        }

        /// <summary>
        /// Tries to invoke a Parse method from the TResult type on the value.
        /// </summary>
        /// <typeparam name="TResult">Containing the parse method</typeparam>
        /// <param name="value">To parse</param>
        /// <param name="result">Parsed value or default on failure</param>
        /// <returns>Success</returns>
        public static bool TryParse<TResult>
            (this string value, out TResult result)
        {
            var methodInfo = typeof(TResult).GetMethod
                ("Parse", new Type[] { typeof(string) });

            if (methodInfo == null)
            {
                result = default(TResult);
                return false;
            }

            result = (TResult) methodInfo.Invoke(null, new object[] { value });
            return true;
        }
    }
}
