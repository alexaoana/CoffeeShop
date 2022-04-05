namespace CoffeeShop.Core
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Email { get; set; }
        public string Password { get; set; }
        public int AddressId { get; set; }  
        public Address Address { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
