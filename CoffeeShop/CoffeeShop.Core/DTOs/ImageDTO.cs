using System.Text.Json.Serialization;

namespace CoffeeShop.Core.DTOs
{
    public class ImageDTO
    { 
        public string AzurePath { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
    }
}
