using Microsoft.AspNetCore.Http;

namespace CoffeeShop.Core.Abstract.Services
{
    public interface IImageService
    {
        Task<string> UploadFormFileAsync(IFormFile file);
        Task<string> UploadStreamToBlobAsync(Func<Stream> openStream, string fileName);
    }
}
