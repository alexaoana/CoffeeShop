using System.Diagnostics.CodeAnalysis;

namespace CoffeeShop.Core.Domain.Comparers
{
    public class ImageEqualityComparer : IEqualityComparer<Image>
    {
        public bool Equals(Image? x, Image? y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] Image obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
