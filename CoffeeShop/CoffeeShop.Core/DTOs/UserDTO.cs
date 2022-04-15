using System.Text.Json.Serialization;

namespace CoffeeShop.Core.DTOs
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AddressCity { get; set; }
        public string AddressStreet { get; set; }
        public string AddressNumber { get; set; }
    }
}
