namespace WhatIsHeDoing.Core.Extensions
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Provides extension methods for <see cref="DateTime">DateTime</see>.
    /// </summary>
    public static class DateTimeExtensions
    {
        private const int DaysInWeek = 7;

        /// <summary>
        /// Gets the date at the next weekday supplied.
        /// </summary>
        /// <param name="dateTime">This date time</param>
        /// <param name="day">At which date we want to find</param>
        /// <returns>Date time</returns>
        /// <remarks>
        /// http://stackoverflow.com/questions/6346119/datetime-get-next-tuesday
        /// </remarks>
        public static DateTime GetNextWeekday(
            this DateTime dateTime, DayOfWeek day) =>
            // The (... + 7) % 7 ensures we end up
            // with a value in the range [0, 6].
            dateTime.AddDays(((int)day - (int)dateTime.DayOfWeek + DaysInWeek) % DaysInWeek);

        /// <summary>
        /// Generates the periods between two date times.
        /// </summary>
        /// <param name="start">Start date</param>
        /// <param name="end">End date</param>
        /// <param name="period">Duration of a period in minutes</param>
        /// <returns>Date times</returns>
        public static IEnumerable<DateTime> PeriodsBetween(
            this DateTime start, DateTime end, uint period = 30)
        {
            for (; start < end; start = start.AddMinutes(period))
            {
                yield return start;
            }
        }
    }
}
