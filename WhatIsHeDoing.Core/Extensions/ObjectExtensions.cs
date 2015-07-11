﻿using System;

namespace WhatIsHeDoing.Core.Extensions
{
    /// <summary>
    /// Provides extension methods for all objects.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Calls any action fluently, such as void functions,
        /// so that calls can be chained to other members of object.
        /// </summary>
        /// <param name="this">Object</param>
        /// <param name="action">To call</param>
        /// <returns>This object</returns>
        /// <exception cref="ArgumentNullException">
        /// If either argument is null
        /// </exception>
        public static object AsFluent
            (this object @this, Action action)
        {
            if (@this == null)
            {
                throw new ArgumentNullException("this");
            }

            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            action();
            return @this;
        }
    }
}
