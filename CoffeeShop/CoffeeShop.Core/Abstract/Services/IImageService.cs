using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Core.Abstract.Services
{
    public interface IImageService
    {
        Task<string> UploadFormFileAsync(IFormFile file);
        Task<string> UploadStreamToBlobAsync(Func<Stream> openStream, string fileName);
    }
}
