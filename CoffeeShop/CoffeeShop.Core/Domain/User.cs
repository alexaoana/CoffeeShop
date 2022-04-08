namespace CoffeeShop.Core
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Discount { get; set; }
        public Address Address { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
