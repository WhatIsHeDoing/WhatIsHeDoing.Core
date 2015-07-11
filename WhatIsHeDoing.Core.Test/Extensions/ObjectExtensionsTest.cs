using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhatIsHeDoing.Core.Extensions;

namespace WhatIsHeDoing.Core.Test.Extensions
{
    public static class ObjectExtensionsTest
    {
        [TestClass]
        public class AsFluent
        {
            public void DoSomething() { }

            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void NullObject()
            {
                ObjectExtensions.AsFluent(null, DoSomething);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void NullAction()
            {
                5.AsFluent(null);
            }

            [TestMethod]
            public void Valid()
            {
                var obj = 5;
                var value = 5;
                const int newValue = 10;
                var returned = 5.AsFluent(() => value = newValue);
                Assert.AreEqual(obj, returned);
                Assert.AreEqual(newValue, value);
            }
        }
    }
}
