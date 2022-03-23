using System.Diagnostics.CodeAnalysis;

namespace CoffeeShop.Core.Domain.Comparers
{
    public class ProductEqualityComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product? x, Product? y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] Product obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
