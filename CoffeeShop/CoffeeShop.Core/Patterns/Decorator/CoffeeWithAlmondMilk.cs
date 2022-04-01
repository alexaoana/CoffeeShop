using CoffeeShop.Core.Abstract.Patterns;

namespace CoffeeShop.Core.Patterns.Decorator
{
    public class CoffeeWithAlmondMilk : CoffeeDecorator
    {
        public CoffeeWithAlmondMilk(Product product) : base(product)
        {
            this._product.Description = this._product.Description + " with almond milk";
            this._product.Amount = this._product.Amount + 20;
            this._product.Price = this._product.Price + 4;
        }
    }
}
