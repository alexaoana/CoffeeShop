using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CoffeeShop.Core
{
    public class Address
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string City { get; set; }
        [Required]
        [MaxLength(100)]
        public string Street { get; set; }
        [Required]
        [MaxLength(4)]
        public string Number { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public Address()
        {

        }
        public Address(int id, string city, string street, string number)
        {
            Id = id;
            City = city;
            Street = street;
            Number = number;
        }
        public Address(string city, string street, string number)
        {
            City = city;
            Street = street;
            Number = number;
        }
    }
}
