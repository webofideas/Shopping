using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Domain
{
    public interface ISpecialOffer
    {
        string Name { get; protected set; }
        List<IItem> RequiredItems { get; protected set; }
        IItem ItemToDiscount { get; protected set; }
        decimal DiscountPercentage { get; protected set; }

        decimal DiscountAmount
        {
            get =>
                Math.Round(
                    ((ISpecialOffer)this).ItemToDiscount.Price * ((ISpecialOffer)this).DiscountPercentage / 100,
                    2);
        }
    }
}
