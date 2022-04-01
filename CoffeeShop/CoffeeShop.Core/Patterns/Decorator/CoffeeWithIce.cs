using CoffeeShop.Core.Abstract.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Core.Patterns.Decorator
{
    public class CoffeeWithIce : CoffeeDecorator
    {
        public CoffeeWithIce(Product product) : base(product)
        {
            this._product.Description = this._product.Description + " with ice";
            this._product.Price = this._product.Price + 1;
            this._product.Amount = this._product.Amount + 30;
        }
    }
}
