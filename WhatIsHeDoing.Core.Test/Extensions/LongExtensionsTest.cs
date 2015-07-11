using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhatIsHeDoing.Core.Extensions;

namespace WhatIsHeDoing.Core.Test.Extensions
{    
    public static class LongExtensionsTest
    {
        [TestClass]
        public class Length
        {
            [TestMethod]
            public void Any()
            {
                Assert.AreEqual(4, (-1234L).Length());
                Assert.AreEqual(2, (-10L).Length());
                Assert.AreEqual(1, (-9L).Length());
                Assert.AreEqual(1, 0L.Length());
                Assert.AreEqual(1, 9L.Length());
                Assert.AreEqual(2, 10L.Length());
                Assert.AreEqual(4, 1234L.Length());
                Assert.IsTrue(long.MaxValue.Length() > 0);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void MinValue()
            {
                LongExtensions.Length(long.MinValue.Length());
            }
        }

        [TestClass]
        public class StripDigits
        {
            [TestMethod]
            public void Any()
            {
                Assert.AreEqual(0, 123L.StripDigits(4));
                Assert.AreEqual(1, 123L.StripDigits(2));
                Assert.AreEqual(12, 123L.StripDigits(1));
                Assert.AreEqual(-1, -123L.StripDigits(2));
                Assert.AreEqual(-12, -123L.StripDigits(1));
                Assert.AreEqual(0, -123L.StripDigits(4));
                
                var minValue = long.MinValue;
                Assert.IsTrue(minValue.StripDigits(1) > minValue);
                
                var maxValue = long.MaxValue;
                Assert.IsTrue(maxValue.StripDigits(1) < maxValue);
            }
        }
    }
}
