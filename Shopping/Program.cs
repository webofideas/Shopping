using Shopping.Domain;
using Shopping.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            // Build a basket
            var basket = new Basket();
            foreach (string inputItem in args)
            {
                if (!basket.AddItem(inputItem))
                {
                    Console.WriteLine($"Item '{inputItem}' not found in store and will not be included in the basket");
                }
            }

            // Apply discounts
            basket.ApplyDiscounts();

            // Generate receipt
            var receipt = basket.Receipt();

            // Display receipt
            foreach (var receiptLine in receipt)
            {
                Console.WriteLine(receiptLine);
            }
        }
    }
}
