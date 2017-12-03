using WhatIsHeDoing.Core.Extensions;
using Xunit;

namespace WhatIsHeDoing.Core.Tests.Extensions
{    
    public static class IntegerExtensionsTest
    {
        public class ToNearestCeiling
        {
            [Theory]
            [InlineData(12, 20)]
            [InlineData(123, 130)]
            [InlineData(-12, -10)]
            public void ToNearestTen(int value, int expected) =>
                Assert.Equal(expected, value.ToNearestCeiling(10));

            [Theory]
            [InlineData(12, 15)]
            [InlineData(123, 125)]
            [InlineData(-12, -10)]
            public void ToNearestFive(int value, int expected) =>
                Assert.Equal(expected, value.ToNearestCeiling(5));
        }
    }
}
