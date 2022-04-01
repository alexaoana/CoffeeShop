using CoffeeShop.Core.Abstract.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Core.Patterns.Decorator
{
    public class CoffeeWithoutCaffeine : CoffeeDecorator
    {
        public CoffeeWithoutCaffeine(Product product) : base(product)
        {
            this._product.Description = this._product.Description + " without caffeine";
            this._product.CoffeeIntensity = 0;
        }
    }
}
