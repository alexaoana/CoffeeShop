using CoffeeShop.Core.Abstract.Patterns;

namespace CoffeeShop.Core.Patterns.Decorator
{
    public class CoffeeWithIce : CoffeeDecorator
    {
        public CoffeeWithIce(ProductOrder product) : base(product)
        {
            this._product.Description = this._product.Description + " with ice";
            this._product.Price = this._product.Price + 1;
            this._product.Amount = this._product.Amount + 30;
        }
    }
}
