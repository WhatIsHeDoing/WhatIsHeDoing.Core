namespace WhatIsHeDoing.Core.Tests.Extensions
{
    using System;
    using WhatIsHeDoing.Core.Extensions;
    using Xunit;

    public static class LongExtensionsTest
    {
        public class Length
        {
            [Fact]
            public void Any()
            {
                Assert.Equal(4, (-1234L).Length());
                Assert.Equal(2, (-10L).Length());
                Assert.Equal(1, (-9L).Length());
                Assert.Equal(1, 0L.Length());
                Assert.Equal(1, 9L.Length());
                Assert.Equal(2, 10L.Length());
                Assert.Equal(4, 1234L.Length());
                Assert.True(long.MaxValue.Length() > 0);
            }

            [Fact]
            public void MinValue() => Assert.Throws<ArgumentOutOfRangeException>(
                () => LongExtensions.Length(long.MinValue.Length()));
        }

        public class StripDigits
        {
            [Fact]
            public void Any()
            {
                Assert.Equal(0, 123L.StripDigits(4));
                Assert.Equal(1, 123L.StripDigits(2));
                Assert.Equal(12, 123L.StripDigits(1));
                Assert.Equal(-1, -123L.StripDigits(2));
                Assert.Equal(-12, -123L.StripDigits(1));
                Assert.Equal(0, -123L.StripDigits(4));

                var minValue = long.MinValue;
                Assert.True(minValue.StripDigits(1) > minValue);

                var maxValue = long.MaxValue;
                Assert.True(maxValue.StripDigits(1) < maxValue);
            }
        }
    }
}
