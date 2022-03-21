using CoffeeShop.Core.Abstract.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Infrastructure.Services
{
    public class AzureBlobImageService : IImageService
    {
        private readonly string _containerName;
        private readonly CloudBlobClient _cloudBlobClient;
        public AzureBlobImageService(string connectionString, string containerName)
        {
            _containerName = containerName;
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            _cloudBlobClient = storageAccount.CreateCloudBlobClient();
        }

        public Task<string> UploadFormFileAsync(IFormFile file)
        {
            return UploadStreamToBlobAsync(file.OpenReadStream, file.FileName);
        }

        public async Task<string> UploadStreamToBlobAsync(Func<Stream> openStream, string fileName)
        {
            string uri = "";
            CloudBlobContainer cloudBlobContainer = await GetBlobContainerAsync(); 
            BlobContainerPermissions permissions = new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            }; 

            await cloudBlobContainer.SetPermissionsAsync(permissions); 
            string path = GetBlobPath(fileName); 
            CloudBlockBlob blob = cloudBlobContainer.GetBlockBlobReference(path);

            if (blob != null)
            {
                using (var stream = openStream())
                await blob.UploadFromStreamAsync(stream); 
                uri = blob.StorageUri.PrimaryUri.ToString();
            }
            return uri;
        }

        private async Task<CloudBlobContainer> GetBlobContainerAsync()
        {
            CloudBlobContainer cloudBlobContainer = _cloudBlobClient.GetContainerReference(_containerName);
            await cloudBlobContainer.CreateIfNotExistsAsync();
            return cloudBlobContainer;
        }

        private static string GetBlobPath(string fileName)
        {
            return $"{Guid.NewGuid()}_{fileName}.jpg";
        }
    }
}
