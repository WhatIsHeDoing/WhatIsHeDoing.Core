using System;
using System.Linq;
using WhatIsHeDoing.Core.Extensions;
using Xunit;

namespace WhatIsHeDoing.Core.Tests.Extensions
{
    public class DateTimeExtensionsTest
    {
        public class GetNextWeekday
        {
            private static readonly DateTime _date = new DateTime(2013, 3, 31);

            [Fact]
            public void VerifyKnownStartDateDay() =>
                Assert.Equal(DayOfWeek.Sunday, _date.DayOfWeek);

            [Fact]
            public void Tomorrow()
            {
                const DayOfWeek dayDateToFind = DayOfWeek.Monday;
                var nextDayDate = _date.GetNextWeekday(dayDateToFind);
                Assert.Equal(dayDateToFind, nextDayDate.DayOfWeek);

                var expectedDate = new DateTime(2013, 4, 1);
                Assert.Equal(expectedDate, nextDayDate);
            }

            [Fact]
            public void SameDay()
            {
                var nextDayDate = _date.GetNextWeekday(DayOfWeek.Sunday);
                Assert.Equal(_date, nextDayDate);
            }

            [Fact]
            public void LastDayOfNextPossibleWeek()
            {
                const DayOfWeek dayDateToFind = DayOfWeek.Saturday;
                var nextDayDate = _date.GetNextWeekday(dayDateToFind);
                Assert.Equal(dayDateToFind, nextDayDate.DayOfWeek);

                var expectedDate = new DateTime(2013, 4, 6);
                Assert.Equal(expectedDate, nextDayDate);
            }
        }

        public class PeriodsBetween
        {
            [Fact]
            public void PeriodDurationLessThanDifference()
            {
                // Assemble.
                var start = new DateTime(2010, 1, 1, 0, 0, 0);
                var end = new DateTime(2010, 1, 1, 2, 0, 0);

                // Act.
                var periodsBetween = start.PeriodsBetween(end).ToList();

                // Assert.
                Assert.NotNull(periodsBetween);
                Assert.Equal(4, periodsBetween.Count);

                Assert.Equal(new[]
                {
                    new DateTime(2010, 1, 1, 0, 0, 0),
                    new DateTime(2010, 1, 1, 0, 30, 0),
                    new DateTime(2010, 1, 1, 1, 0, 0),
                    new DateTime(2010, 1, 1, 1, 30, 0)
                }, periodsBetween);
            }

            [Fact]
            public void PeriodDurationGreaterThanDifference()
            {
                // Assemble.
                var start = new DateTime(2010, 1, 1, 0, 0, 0);
                var end = new DateTime(2010, 1, 1, 1, 0, 0);

                // Act.
                var periodsBetween = start.PeriodsBetween(end, 90).ToList();

                // Assert.
                Assert.Single(periodsBetween);

                var expectedFirstPeriod = new DateTime(2010, 1, 1, 0, 0, 0);
                Assert.Equal(expectedFirstPeriod, periodsBetween[0]);
            }

            [Fact]
            public void StartGreaterThanEnd()
            {
                // Assemble.
                var start = new DateTime(2010, 1, 1, 1, 0, 0);
                var end = new DateTime(2010, 1, 1, 0, 0, 0);

                // Act.
                var periodsBetween = start.PeriodsBetween(end).ToList();

                // Assert.
                Assert.Empty(periodsBetween);
            }
        }
    }
}
