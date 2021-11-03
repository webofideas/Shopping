using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Domain
{
    public interface IItem
    {
        string Name { get; protected set; }
        decimal Price { get; protected set; }
    }
}
