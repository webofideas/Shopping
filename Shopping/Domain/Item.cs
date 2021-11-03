using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Domain
{
    public class Item : IItem
    {
        private string description;
        private decimal price;

        public Item (string description, decimal price)
        {
            this.description = description;
            this.price = price;
        }
        string IItem.Name { get => this.description; set => this.description = value; }
        decimal IItem.Price { get => this.price; set => this.price = value; }
    }
}
