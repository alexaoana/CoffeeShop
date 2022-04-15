using CoffeeShop.Core.Abstract.Patterns;

namespace CoffeeShop.Core.Patterns.Decorator
{
    public class CoffeeWithMilk : CoffeeDecorator
    {
        public CoffeeWithMilk(ProductOrder product) : base(product)
        {
            this._product.Description = this._product.Description + " with extra milk";
            this._product.Price = this._product.Price + 2;
            this._product.Amount = this._product.Amount + 20;
        }
    }
}
