using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shopping.ExtensionMethods;
using System.Collections.Generic;
using System.Linq;

namespace Shopping.Tests.Unit
{
    [TestClass]
    public class ExtensionMethodsTests
    {
        [DataTestMethod]
        [DataRow(new string[] { "Item1" }, true)]
        [DataRow(new string[] { "item1" }, false)]
        [DataRow(new string[] { "Item1", "Item2" }, true)]
        [DataRow(new string[] { "Item1", "item2" }, false)]
        [DataRow(new string[] { "Item1", "Item2", "Item3" }, false)]
        public void ContainsAllItems_WithoutDuplicates_ReturnsCorrectValue(string[] containsValues, bool expectedResult)
        {
            // Arrange
            var items = new List<string> { "Item1", "Item2" };

            // Act
            var result = items.ContainsAllItems(containsValues.ToList());

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [DataTestMethod]
        [DataRow(new string[] { "Item1" }, true)]
        [DataRow(new string[] { "Item1", "Item1" }, false)]
        [DataRow(new string[] { "Item1", "Item2" }, true)]
        [DataRow(new string[] { "Item1", "Item2", "Item2" }, true)]
        [DataRow(new string[] { "Item1", "Item2", "Item2", "Item2" }, true)]
        [DataRow(new string[] { "Item1", "Item2", "Item2", "Item2", "Item2" }, false)]
        [DataRow(new string[] { "Item1", "Item2", "Item2", "Item2", "Item3" }, false)]
        public void ContainsAllItems_WithDuplicates_ReturnsCorrectValue(string[] containsValues, bool expectedResult)
        {
            // Arrange
            var items = new List<string> { "Item1", "Item2", "Item2", "Item2", };

            // Act
            var result = items.ContainsAllItems(containsValues.ToList());

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void RemoveAllItems_WithoutDuplicates_RemovesCorrectly()
        {
            // Arrange
            var items = new List<string> { "Item1", "Item2", "Item3" };

            // Act
            var result = items.RemoveAllItems(new List<string>() { "Item1", "Item3" });

            // Assert
            Assert.AreEqual(1, items.Count());
            Assert.AreEqual("Item2", items[0]);
        }

        [TestMethod]
        public void RemoveAllItems_WithDuplicates_RemovesCorrectly()
        {
            // Arrange
            var items = new List<string> { "Item1", "Item2", "Item3", "Item3" };

            // Act
            var result = items.RemoveAllItems(new List<string>() { "Item1", "Item3" });

            // Assert
            Assert.AreEqual(2, items.Count());
            Assert.AreEqual("Item2", items[0]);
            Assert.AreEqual("Item3", items[1]);
        }

    }
}
