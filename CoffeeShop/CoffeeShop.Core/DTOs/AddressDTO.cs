using System.Text.Json.Serialization;

namespace CoffeeShop.Core.DTOs
{
    public class AddressDTO
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
