using System;
using WhatIsHeDoing.Core.Extensions;
using Xunit;

namespace WhatIsHeDoing.Core.Tests.Extensions
{
    public static class StringExtensionsTest
    {
        public class AsCurrency
        {
            [Fact]
            public void Valid()
            {
                const string toConvert = "1.450";
                const string expected = "1.45";
                var actual = toConvert.AsCurrency();
                Assert.Equal(expected, actual);
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData(" ")]
            [InlineData("oops")]
            public void InvalidCurrency(string currency) =>
                Assert.Equal(currency, currency.AsCurrency());
        }

        public class IsTrue
        {
            [Theory]
            [InlineData("")]
            [InlineData(" ")]
            [InlineData(null)]
            [InlineData("oops")]
            public void InvalidBoolean(string value) =>
                Assert.False(value.IsTrue());

            [Theory]
            [InlineData("true")]
            [InlineData("True")]
            [InlineData("TRUE")]
            public void ValidTrueBooleans(string format) =>
                Assert.True(format.IsTrue());

            [Fact]
            public void InvalidTrueBoolean() => Assert.False("1".IsTrue());
        }

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

        public class ToBytes
        {
            [Fact]
            public void Valid()
            {
                const string byteString = "5,1";
                var actual = byteString.ToBytes();
                var expected = new byte[] { 5, 1 };
                Assert.Equal(expected, actual);
            }

            [Fact]
            public void HandlesWhitespace()
            {
                const string byteString = "5, 1";
                var actual = byteString.ToBytes();
                var expected = new byte[] { 5, 1 };
                Assert.Equal(expected, actual);
            }
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
