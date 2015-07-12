using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhatIsHeDoing.Core.Extensions;

namespace WhatIsHeDoing.Core.Test.Extensions
{
    public class IEnumerableExtensionsTest
    {
        [TestClass]
        public class IterateJagged
        {
            [TestMethod]
            public void NonJagged()
            {
                var firstRow = new int[] { 1, 2, 3 };
                var secondRow = new int[] { 4, 5, 6 };
                var thirdRow = new int[] { 7, 8, 9 };

                var actual = firstRow.IterateJagged(secondRow, thirdRow).ToArray();
                Assert.AreEqual(9, actual.Length, "All items returned");

                var expectedFirstColumn = new int[] { 1, 4, 7 };
                var actualFirstColumn = actual.Take(3).ToArray();

                CollectionAssert.AreEqual(expectedFirstColumn,
                    actualFirstColumn, "First column");

                var expectedSecondColumn = new int[] { 2, 5, 8 };
                var actualSecondColumn = actual.Skip(3).Take(3).ToArray();

                CollectionAssert.AreEqual(expectedSecondColumn,
                    actualSecondColumn, "Second column");

                var expectedThirdColumn = new int[] { 3, 6, 9 };
                var actualThirdColumn = actual.Skip(6).Take(3).ToArray();

                CollectionAssert.AreEqual(expectedThirdColumn,
                    actualThirdColumn, "Third column");
            }

            [TestMethod]
            public void SimpleJaggedCollections()
            {
                var first = new int[] { 1 };
                var second = new int[] { 2, 3 };
                var third = new int[] { 4 };
                var result = first.IterateJagged(second, third).ToArray();
                CollectionAssert.AreEqual(new [] { 1, 2, 4, 3 }, result);
            }

            [TestMethod]
            public void JaggedWithEmptyAndNullCollections()
            {
                var firstRow = new List<int> { 1 };
                var secondRow = new List<int> { 4, 5 };
                List<int> thirdRow = null;
                var fourthRow = new List<int> { 7, 8, 9 };
                var fifthRow = new List<int>();
                var sixthRow = new List<int> { 10, 11 };

                var actual = firstRow.IterateJagged
                        (secondRow, thirdRow, fourthRow, fifthRow, sixthRow)
                    .ToList();

                Assert.AreEqual(8, actual.Count, "All items returned");

                var expectedFirstColumn = new List<int> { 1, 4, 7, 10 };
                var actualFirstColumn = actual.Take(4).ToList();

                CollectionAssert.AreEqual(expectedFirstColumn,
                    actualFirstColumn, "First column");

                var expectedSecondColumn = new List<int> { 5, 8, 11 };
                var actualSecondColumn = actual.Skip(4).Take(3).ToList();

                CollectionAssert.AreEqual(expectedSecondColumn,
                    actualSecondColumn, "Second column");

                var expectedThirdColumn = new List<int> { 9 };
                var actualThirdColum = actual.Skip(7).Take(1).ToList();

                CollectionAssert.AreEqual(expectedThirdColumn,
                    actualThirdColum, "Third column");
            }
        }

        [TestClass]
        public class ZipJagged
        {
            [TestMethod]
            public void NonJagged()
            {
                var firstRow = new int[] { 1, 2, 3 };
                var secondRow = new int[] { 4, 5, 6 };
                var thirdRow = new int[] { 7, 8, 9 };

                var actual = firstRow.ZipJagged(secondRow, thirdRow).ToArray();
                Assert.AreEqual(3, actual.Length, "All columns returned");

                var expectedFirstColumn = new int[] { 1, 4, 7 };
                var actualFirstColumn = actual[0].ToArray();

                CollectionAssert.AreEqual(expectedFirstColumn,
                    actualFirstColumn, "First column");

                var expectedSecondColumn = new int[] { 2, 5, 8 };
                var actualSecondColumn = actual[1].ToArray();

                CollectionAssert.AreEqual(expectedSecondColumn,
                    actualSecondColumn, "Second column");

                var expectedThirdColumn = new int[] { 3, 6, 9 };
                var actualThirdColumn = actual[2].ToArray();

                CollectionAssert.AreEqual(expectedThirdColumn,
                    actualThirdColumn, "Third column");
            }

            [TestMethod]
            public void JaggedWithEmptyAndNullCollections()
            {
                var firstRow = new List<int> { 1 };
                var secondRow = new List<int> { 4, 5 };
                List<int> thirdRow = null;
                var fourthRow = new List<int> { 7, 8, 9 };
                var fifthRow = new List<int>();
                var sixthRow = new List<int> { 10, 11 };

                var actual = firstRow.ZipJagged
                        (secondRow, thirdRow, fourthRow, fifthRow, sixthRow)
                    .ToList();

                Assert.AreEqual(3, actual.Count, "All columns returned");

                var expectedFirstColumn = new List<int> { 1, 4, 7, 10 };
                var actualFirstColumn = actual[0].ToList();

                CollectionAssert.AreEqual(expectedFirstColumn,
                    actualFirstColumn, "First column");

                var expectedSecondColumn = new List<int> { 5, 8, 11 };
                var actualSecondColumn = actual[1].ToList();

                CollectionAssert.AreEqual(expectedSecondColumn,
                    actualSecondColumn, "Second column");

                var expectedThirdColumn = new List<int> { 9 };
                var actualThirdColum = actual[2].ToList();

                CollectionAssert.AreEqual(expectedThirdColumn,
                    actualThirdColum, "Third column");
            }
        }
    }
}
