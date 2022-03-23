using System.Diagnostics.CodeAnalysis;

namespace CoffeeShop.Core.Domain.Comparers
{
    public class OrderEqualityComparer : IEqualityComparer<Order>
    {
        public bool Equals(Order? x, Order? y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] Order obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
