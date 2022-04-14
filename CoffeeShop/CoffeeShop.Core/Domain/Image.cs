using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CoffeeShop.Core.Domain
{
    public class Image
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string AzurePath { get; set; }
        [JsonIgnore]
        public int ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        public Image()
        {

        }
        public Image(int id, string azurePath)
        {
            Id = id;
            AzurePath = azurePath;
        }
        public Image(string azurePath)
        {
            AzurePath = azurePath;
        }
    }
}
