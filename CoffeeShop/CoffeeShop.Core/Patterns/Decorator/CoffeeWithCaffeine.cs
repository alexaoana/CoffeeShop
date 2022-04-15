using CoffeeShop.Core.Abstract.Patterns;

namespace CoffeeShop.Core.Patterns.Decorator
{
    public class CoffeeWithCaffeine : CoffeeDecorator
    {
        public CoffeeWithCaffeine(ProductOrder product) : base(product)
        {
            this._product.Description = this._product.Description + " with extra caffeine";
            this._product.Price = this._product.Price + 3;
            this._product.CoffeeIntensity = this._product.CoffeeIntensity + 4;
            this._product.Amount = this._product.Amount + 20;
        }
    }
}
