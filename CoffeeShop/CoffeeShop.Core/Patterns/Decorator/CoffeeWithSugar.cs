using CoffeeShop.Core.Abstract.Patterns;

namespace CoffeeShop.Core.Patterns.Decorator
{
    public class CoffeeWithSugar : CoffeeDecorator
    {
        public CoffeeWithSugar(Product product) : base(product)
        {
            this._product.Description = this._product.Description + " with extra sugar";
            this._product.Price = this._product.Price + 1;
        }
    }
}
