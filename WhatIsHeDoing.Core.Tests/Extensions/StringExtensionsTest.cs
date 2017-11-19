using System;
using WhatIsHeDoing.Core.Extensions;
using Xunit;

namespace WhatIsHeDoing.Core.Tests.Extensions
{
    public static class StringExtensionsTest
    {
        public class Parse
        {
            [Fact]
            public void Valid()
            {
                var i = "123".Parse<int>();
                Assert.Equal(123, i);

                var d = "12.3".Parse<double>();
                Assert.Equal(12.3, d);

                var de = "12.3".Parse<decimal>();
                Assert.Equal(12.3m, de);
            }

            [Fact]
            public void Invalid() => Assert.Throws<TypeLoadException>
                (() => "123".Parse<string>());
        }

        public class TryParse
        {
            [Fact]
            public void Valid()
            {
                var result = "123".TryParse(out int i);
                Assert.True(result);
                Assert.Equal(123, i);

                result = "12.3".TryParse(out double d);
                Assert.True(result);
                Assert.Equal(12.3, d);

                result = "123".TryParse(out decimal dec);
                Assert.True(result);
                Assert.Equal(123m, dec);
            }

            [Fact]
            public void Invalid()
            {
                var result = "123".TryParse(out string s);
                Assert.False(result);
                Assert.Null(s);
            }
        }
    }
}
