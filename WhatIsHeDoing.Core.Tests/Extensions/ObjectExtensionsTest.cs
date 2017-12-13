namespace WhatIsHeDoing.Core.Tests.Extensions
{
    using System;
    using WhatIsHeDoing.Core.Extensions;
    using Xunit;

    public static class ObjectExtensionsTest
    {
        public class AsFluent
        {
            [Fact]
            public void NullObject() => Assert.Throws<ArgumentNullException>(
                () => ObjectExtensions.AsFluent<string>(null, DoSomething));

            [Fact]
            public void NullAction() => Assert.Throws<ArgumentNullException>(
                () => 5.AsFluent(null));

            [Fact]
            public void Simple()
            {
                var obj = 5;
                var value = 5;
                const int newValue = 10;
                var returned = 5.AsFluent(() => value = newValue);
                Assert.Equal(obj, returned);
                Assert.Equal(newValue, value);
            }

            [Fact]
            public void ChainOldSkoolVoidSetter()
            {
                const int expected = 5;
                var chainMe = new ChainMe();

                var actual = chainMe
                    .AsFluent(() => chainMe.SetValue(expected))
                    .GetValue();

                Assert.Equal(expected, actual);
            }

            internal void DoSomething()
            {
            }

            internal class ChainMe
            {
                private int _value;
                public int GetValue() => _value;

                // return this; // Would have been useful!
                public void SetValue(int value) => _value = value;
            }
        }
    }
}
