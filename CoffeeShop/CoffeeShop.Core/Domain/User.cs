using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Core
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        public string Password { get; set; }
        [Required]
        public decimal Discount { 
            get
            {
                return Discount;
            }
            set
            {
                if (value >= 0 && value <= 1)
                    Discount = value;
            }
        }
        public Address Address { get; set; }
        public List<Order>? Orders { get; set; }
        public User(int id, string firstName, string lastName, string email, string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Discount = decimal.One;
            Orders = new List<Order>();
        }
        public User(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Discount = decimal.One;
            Orders = new List<Order>();
        }
    }
}
