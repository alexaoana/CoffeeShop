namespace CoffeeShop.Core.Abstract.Patterns
{
    public abstract class CoffeeDecorator : Product
    {
        protected Product _product;

        public CoffeeDecorator(Product product)
        {
            _product = product;
        }

        public Product GetProduct()
        {
            return _product;
        }
    }
}
