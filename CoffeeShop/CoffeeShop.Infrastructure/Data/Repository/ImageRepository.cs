using CoffeeShop.Core.Abstract.Repository;
using CoffeeShop.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Infrastructure.Data.Repository
{
    public class ImageRepository : IImageRepository
    {
        private AppDbContext _appDbContext;
        public ImageRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Image GetImage(int id)
        {
            return _appDbContext.Images
                .Include(x => x.Product)
                .SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Image> GetImages()
        {
            return _appDbContext.Images;
        }

        public void AddImage(Image image)
        {
            _appDbContext.Images.Add(image);
            _appDbContext.SaveChanges();
        }

        public void DeleteImage(int id)
        {
            var image = GetImage(id);
            _appDbContext.Images.Remove(image);
            _appDbContext.SaveChanges();
        }

        public void UpdateImage(Image image)
        {
            foreach (var item in _appDbContext.Images)
                if (item.Id == image.Id)
                    item.AzurePath = image.AzurePath;
            _appDbContext.SaveChanges();
        }
    }
}
