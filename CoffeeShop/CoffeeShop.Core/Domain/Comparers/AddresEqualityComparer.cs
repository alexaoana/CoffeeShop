using System.Diagnostics.CodeAnalysis;

namespace CoffeeShop.Core.Domain.Comparers
{
    public class AddresEqualityComparer : IEqualityComparer<Address>
    {
        public bool Equals(Address? x, Address? y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] Address obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
