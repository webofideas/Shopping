using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Domain
{
    public class SpecialOffer : ISpecialOffer
    {
        private string name;
        private List<IItem> requiredItems;
        private IItem itemToDiscount;
        private decimal discountPercentage;

        public SpecialOffer(string name, List<IItem> requiredItems, IItem itemToDiscount, decimal discountPercentage)
        {
            this.name = name;
            this.requiredItems = requiredItems;
            this.itemToDiscount = itemToDiscount;
            this.discountPercentage = discountPercentage;
        }

        string ISpecialOffer.Name { get => this.name; set => this.name = value; }
        List<IItem> ISpecialOffer.RequiredItems { get => this.requiredItems; set => this.requiredItems = value; }
        IItem ISpecialOffer.ItemToDiscount { get => this.itemToDiscount; set => this.itemToDiscount = value; }
        decimal ISpecialOffer.DiscountPercentage { get => this.discountPercentage; set => this.discountPercentage = value; }
    }
}
