using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shopping.Domain;
using Shopping.ExtensionMethods;
using System.Collections.Generic;
using System.Linq;

namespace Shopping.Tests.Unit
{
    [TestClass]
    public class BasketTests
    {
        [DataTestMethod]
        [DataRow(new string[] { "bread", "butter" }, 1.80)]
        [DataRow(new string[] { "bread", "butter", "milk" }, 2.95)]
        [DataRow(new string[] { "bread", "bread", "butter", "butter" }, 3.10)]
        [DataRow(new string[] { "milk", "milk", "milk", "milk" }, 3.45)]
        [DataRow(new string[] { "milk", "milk", "milk", "milk", "butter", "butter", "bread", "milk", "milk", "milk", "milk" }, 9.00)]
        public void BasketValue_WithVariousItems_CalcualtesCorrectTotal(string[] items, double basketTotal)
        {
            // Arrange
            var basket = new Basket();

            // Act
            foreach (var item in items)
            {
                basket.AddItem(item);
            }
            basket.ApplyDiscounts();

            // Assert
            Assert.AreEqual(basket.BasketValue, (decimal)basketTotal);
        }

    }
}
