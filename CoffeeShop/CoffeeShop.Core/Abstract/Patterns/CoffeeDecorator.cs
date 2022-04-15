namespace CoffeeShop.Core.Abstract.Patterns
{
    public abstract class CoffeeDecorator : ProductOrder
    {
        protected ProductOrder _product;

        public CoffeeDecorator(ProductOrder product)
        {
            _product = product;
        }

        public ProductOrder GetProduct()
        {
            return _product;
        }
    }
}
