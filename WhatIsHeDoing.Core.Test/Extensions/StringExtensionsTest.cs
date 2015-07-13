using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhatIsHeDoing.Core.Extensions;

namespace WhatIsHeDoing.Core.Test.Extensions
{
    public static class StringExtensionsTest
    {
        [TestClass]
        public class Parse
        {
            [TestMethod]
            public void Valid()
            {
                var i = "123".Parse<int>();
                Assert.AreEqual(123, i);

                var d = "12.3".Parse<double>();
                Assert.AreEqual(12.3, d);

                var de = "12.3".Parse<decimal>();
                Assert.AreEqual(12.3m, de);
            }

            [TestMethod]
            [ExpectedException(typeof(TypeLoadException))]
            public void Invalid()
            {
                "123".Parse<string>();
            }
        }

        [TestClass]
        public class TryParse
        {
            [TestMethod]
            public void Valid()
            {
                int i;
                var result = "123".TryParse<int>(out i);
                Assert.IsTrue(result);
                Assert.AreEqual(123, i);

                double d;
                result = "12.3".TryParse<double>(out d);
                Assert.IsTrue(result);
                Assert.AreEqual(12.3, d);

                decimal dec;
                result = "123".TryParse<decimal>(out dec);
                Assert.IsTrue(result);
                Assert.AreEqual(123m, dec);
            }

            [TestMethod]
            public void Invalid()
            {
                string s;
                var result = "123".TryParse<string>(out s);
                Assert.IsFalse(result);
                Assert.IsNull(s);
            }
        }
    }
}
