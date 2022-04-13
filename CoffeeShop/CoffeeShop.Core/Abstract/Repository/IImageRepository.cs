using CoffeeShop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Core.Abstract.Repository
{
    public interface IImageRepository
    {
        public Image GetImage(int id);
        public IEnumerable<Image> GetImages();
        public void AddImage(Image image);
        public void DeleteImage(int id);
        public void UpdateImage(Image image);
    }
}
