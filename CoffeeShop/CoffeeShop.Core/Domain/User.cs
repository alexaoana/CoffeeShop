namespace CoffeeShop.Core
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
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
