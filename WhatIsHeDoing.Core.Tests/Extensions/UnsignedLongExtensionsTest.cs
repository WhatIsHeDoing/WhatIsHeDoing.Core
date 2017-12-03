using WhatIsHeDoing.Core.Extensions;
using Xunit;

namespace WhatIsHeDoing.Core.Tests.Extensions
{    
    public static class UnsignedLongExtensionsTest
    {
        public class Length
        {
            [Fact]
            public void Any()
            {
                Assert.Equal(1UL, 0UL.Length());
                Assert.Equal(1UL, 9UL.Length());
                Assert.Equal(2UL, 10UL.Length());
                Assert.Equal(4UL, 1234UL.Length());
                Assert.True(ulong.MaxValue.Length() > 0);
            }
        }

        public class StripDigits
        {
            [Fact]
            public void Any()
            {
                Assert.Equal(0UL, 123UL.StripDigits(4));
                Assert.Equal(1UL, 123UL.StripDigits(2));
                Assert.Equal(12UL, 123UL.StripDigits(1));
                
                var minValue = ulong.MinValue;
                var minValueStripped = minValue.StripDigits(1);
                Assert.Equal(minValue, minValueStripped);
                
                var maxValue = ulong.MaxValue;
                var maxValueStripped = maxValue.StripDigits(1);
                Assert.True(maxValueStripped < maxValue);
            }
        }
    }
}
