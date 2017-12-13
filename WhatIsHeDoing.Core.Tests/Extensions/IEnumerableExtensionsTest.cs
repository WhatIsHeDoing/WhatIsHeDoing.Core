namespace WhatIsHeDoing.Core.Tests.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WhatIsHeDoing.Core.Extensions;
    using Xunit;

    public class IEnumerableExtensionsTest
    {
        public class Aggregate
        {
            [Fact]
            public void MultiplicationByIndex()
            {
                var collection = Enumerable.Range(0, 4);

                var actual = collection.Aggregate(
                    0, (agg, value, index) => agg + (value * index));

                const int expected = (0 * 0) + (1 * 1) + (2 * 2) + (3 * 3);
                Assert.Equal(expected, actual);
            }
        }

        public class IterateJagged
        {
            [Fact]
            public void NonJagged()
            {
                var firstRow = new int[] { 1, 2, 3 };
                var secondRow = new int[] { 4, 5, 6 };
                var thirdRow = new int[] { 7, 8, 9 };

                var actual = firstRow.IterateJagged(secondRow, thirdRow).ToArray();
                Assert.Equal(9, actual.Length);

                var expectedFirstColumn = new int[] { 1, 4, 7 };
                var actualFirstColumn = actual.Take(3).ToArray();

                Assert.Equal(expectedFirstColumn, actualFirstColumn);

                var expectedSecondColumn = new int[] { 2, 5, 8 };
                var actualSecondColumn = actual.Skip(3).Take(3).ToArray();

                Assert.Equal(expectedSecondColumn, actualSecondColumn);

                var expectedThirdColumn = new int[] { 3, 6, 9 };
                var actualThirdColumn = actual.Skip(6).Take(3).ToArray();

                Assert.Equal(expectedThirdColumn, actualThirdColumn);
            }

            [Fact]
            public void SimpleJaggedCollections()
            {
                var first = new int[] { 1 };
                var second = new int[] { 2, 3 };
                var third = new int[] { 4 };
                var result = first.IterateJagged(second, third).ToArray();
                Assert.Equal(new[] { 1, 2, 4, 3 }, result);
            }

            [Fact]
            public void JaggedWithEmptyAndNullCollections()
            {
                var firstRow = new List<int> { 1 };
                var secondRow = new List<int> { 4, 5 };
                List<int> thirdRow = null;
                var fourthRow = new List<int> { 7, 8, 9 };
                var fifthRow = new List<int>();
                var sixthRow = new List<int> { 10, 11 };

                var actual = firstRow
                    .IterateJagged(secondRow, thirdRow, fourthRow, fifthRow, sixthRow)
                    .ToList();

                Assert.Equal(8, actual.Count);

                var expectedFirstColumn = new List<int> { 1, 4, 7, 10 };
                var actualFirstColumn = actual.Take(4).ToList();

                Assert.Equal(expectedFirstColumn, actualFirstColumn);

                var expectedSecondColumn = new List<int> { 5, 8, 11 };
                var actualSecondColumn = actual.Skip(4).Take(3).ToList();

                Assert.Equal(expectedSecondColumn, actualSecondColumn);

                var expectedThirdColumn = new List<int> { 9 };
                var actualThirdColum = actual.Skip(7).Take(1).ToList();

                Assert.Equal(expectedThirdColumn, actualThirdColum);
            }
        }

        public class Randomise
        {
            [Fact]
            public void ThrowsForNull() => Assert.Throws<ArgumentNullException>(
                () => IEnumerableExtensions.Randomise<IEnumerable<int>>(null));

            [Fact]
            public void Randomises()
            {
                var integers = Enumerable.Range(0, 1000).ToList();

                var randomised = integers.Randomise().ToList();
                Assert.Equal(integers.Count, randomised.Count);
                Assert.NotEqual(integers, randomised);

                var resorted = randomised.OrderBy(i => i);
                Assert.Equal(integers, resorted);
            }
        }

        public class WhereNotNull
        {
            [Fact]
            public void FiltersNulls()
            {
                var strings = new List<string> { "Hello", null, "world!" };
                var actual = strings.WhereNotNull();
                var expected = new List<string> { "Hello", "world!" };
                Assert.Equal(expected, actual);
            }

            [Fact]
            public void ThrowsForNull() => Assert.Throws<ArgumentNullException>(
                () => IEnumerableExtensions.WhereNotNull<List<int>>(null));
        }

        public class ZipJagged
        {
            [Fact]
            public void NonJagged()
            {
                var firstRow = new int[] { 1, 2, 3 };
                var secondRow = new int[] { 4, 5, 6 };
                var thirdRow = new int[] { 7, 8, 9 };

                var actual = firstRow.ZipJagged(secondRow, thirdRow).ToArray();
                Assert.Equal(3, actual.Length);

                var expectedFirstColumn = new int[] { 1, 4, 7 };
                var actualFirstColumn = actual[0].ToArray();

                Assert.Equal(expectedFirstColumn, actualFirstColumn);

                var expectedSecondColumn = new int[] { 2, 5, 8 };
                var actualSecondColumn = actual[1].ToArray();

                Assert.Equal(expectedSecondColumn, actualSecondColumn);

                var expectedThirdColumn = new int[] { 3, 6, 9 };
                var actualThirdColumn = actual[2].ToArray();

                Assert.Equal(expectedThirdColumn, actualThirdColumn);
            }

            [Fact]
            public void JaggedWithEmptyAndNullCollections()
            {
                var firstRow = new List<int> { 1 };
                var secondRow = new List<int> { 4, 5 };
                List<int> thirdRow = null;
                var fourthRow = new List<int> { 7, 8, 9 };
                var fifthRow = new List<int>();
                var sixthRow = new List<int> { 10, 11 };

                var actual = firstRow
                    .ZipJagged(secondRow, thirdRow, fourthRow, fifthRow, sixthRow)
                    .ToList();

                Assert.Equal(3, actual.Count);

                var expectedFirstColumn = new List<int> { 1, 4, 7, 10 };
                var actualFirstColumn = actual[0].ToList();

                Assert.Equal(expectedFirstColumn, actualFirstColumn);

                var expectedSecondColumn = new List<int> { 5, 8, 11 };
                var actualSecondColumn = actual[1].ToList();

                Assert.Equal(expectedSecondColumn, actualSecondColumn);

                var expectedThirdColumn = new List<int> { 9 };
                var actualThirdColum = actual[2].ToList();

                Assert.Equal(expectedThirdColumn, actualThirdColum);
            }
        }
    }
}
