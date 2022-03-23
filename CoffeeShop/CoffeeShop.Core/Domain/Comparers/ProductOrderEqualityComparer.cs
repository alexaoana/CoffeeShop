using System.Diagnostics.CodeAnalysis;

namespace CoffeeShop.Core.Domain.Comparers
{
    public class ProductOrderEqualityComparer : IEqualityComparer<ProductOrder>
    {
        public bool Equals(ProductOrder? x, ProductOrder? y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] ProductOrder obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
