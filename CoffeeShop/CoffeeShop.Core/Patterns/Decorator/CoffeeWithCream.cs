using CoffeeShop.Core.Abstract.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Core.Patterns.Decorator
{
    public class CoffeeWithCream : CoffeeDecorator
    {
        public CoffeeWithCream(Product product) : base(product)
        {
            this._product.Description = this._product.Description + " with extra cream";
            this._product.Amount = this._product.Amount + 10;
            this._product.Price = this._product.Price + 2;
        }
    }
}
