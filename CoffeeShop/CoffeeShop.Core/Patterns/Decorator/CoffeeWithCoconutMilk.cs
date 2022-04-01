using CoffeeShop.Core.Abstract.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Core.Patterns.Decorator
{
    public class CoffeeWithCoconutMilk : CoffeeDecorator
    {
        public CoffeeWithCoconutMilk(Product product) : base(product)
        {
            this._product.Description = this._product.Description + " with coconut milk";
            this._product.Price = this._product.Price + 4;
            this._product.Amount = this._product.Amount + 20;
        }
    }
}
