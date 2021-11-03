using Shopping.ExtensionMethods;
using System.Collections.Generic;
using System.Linq;

namespace Shopping.Domain
{
    public class Basket
    {
        // Build available products (these should be moved to config or a data store if productionised)
        static readonly IItem butter = new Item("Butter", 0.80m);
        static readonly IItem milk = new Item("Milk", 1.15m);
        static readonly IItem bread = new Item("Bread", 1.00m);
        static readonly List<IItem> Items = new List<IItem>() { butter, milk, bread };

        // Build special offers (these should be moved to config or a data store if productionised)
        static readonly List<ISpecialOffer> SpecialOffers = new List<ISpecialOffer>()
        {
            new SpecialOffer (
                "Buy 2 butter and get a bread at 50% off",
                new List<IItem>() { butter, butter, bread },
                bread,
                50m),
            new SpecialOffer (
                "Buy 3 milk and get the 4th milk for free",
                new List<IItem>() { milk, milk, milk, milk },
                milk,
                100m)
        };

        public List<IItem> BasketItems = new List<IItem>();
        public List<Discount> Discounts = new List<Discount>();
        
        /// <summary>
        /// Adds the item and returns true if the item is found, false if item is not found.
        /// Match is case-insensitive and trims whitespace.
        /// </summary>
        /// <param name="itemName">The name of the item</param>
        /// <returns></returns>
        public bool AddItem(string itemName)
        {
            foreach (IItem item in Items)
            {
                if (itemName.Trim().ToLower() == item.Name.Trim().ToLower())
                {
                    BasketItems.Add(item);
                    return true;
                }
            }
            return false;
        }

        public void ApplyDiscounts()
        {
            // Work off a cloned copy of the basket so we can remove items as we discount them
            // and thus allow for multiple offers of the same type in a single basket
            var clonedBasket = BasketItems.Select(i => i.Name).ToList().Clone();
            this.Discounts.Clear();

            var offersExhausted = false;
            do
            {
                offersExhausted = true;
                foreach (ISpecialOffer offer in SpecialOffers)
                {
                    if (clonedBasket.ContainsAllItems(offer.RequiredItems.Select(i => i.Name).ToList()))
                    {
                        this.Discounts.Add(new Discount() { Name = offer.Name, Amount = offer.DiscountAmount });
                        clonedBasket.RemoveAllItems(offer.RequiredItems.Select(i => i.Name).ToList());
                        offersExhausted = false;
                    }
                }
            } while (!offersExhausted);
        }

        /// <summary>
        /// Returns an itemised receipt comprising of:
        ///  - all items
        ///  - all discounts
        ///  - the total
        /// </summary>
        /// <returns></returns>
        public List<string> Receipt()
        {
            var receipt = new List<string>();
            foreach (var item in this.BasketItems)
            {
                receipt.Add($"{item.Name}  {item.Price:£#0.00}");
            }
            foreach (var discount in this.Discounts)
            {
                receipt.Add($"{discount.Name}  {discount.Amount:-£#0.00}");
            }
            receipt.Add($"TOTAL: {this.BasketValue:£#0.00}");

            return receipt;
        }

        /// <summary>
        /// Returns total value of basket, including discounts
        /// </summary>
        /// <returns></returns>
        public decimal BasketValue 
        {
            get
            {
                decimal total = 0;
                foreach (var item in this.BasketItems)
                {
                    total += item.Price;
                }
                foreach (var discount in this.Discounts)
                {
                    total -= discount.Amount;
                }
                return total;
            }
        }
    }
}
