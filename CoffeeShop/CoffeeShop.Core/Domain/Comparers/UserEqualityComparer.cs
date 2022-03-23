using System.Diagnostics.CodeAnalysis;

namespace CoffeeShop.Core.Domain.Comparers
{
    public class UserEqualityComparer : IEqualityComparer<User>
    {
        public bool Equals(User? x, User? y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] User obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
