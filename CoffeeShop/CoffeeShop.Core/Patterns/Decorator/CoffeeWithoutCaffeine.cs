using CoffeeShop.Core.Abstract.Patterns;

namespace CoffeeShop.Core.Patterns.Decorator
{
    public class CoffeeWithoutCaffeine : CoffeeDecorator
    {
        public CoffeeWithoutCaffeine(ProductOrder product) : base(product)
        {
            this._product.Description = this._product.Description + " without caffeine";
            this._product.CoffeeIntensity = 0;
        }
    }
}
