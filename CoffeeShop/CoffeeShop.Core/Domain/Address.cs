namespace CoffeeShop.Core
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public User User { get; set; } 
    }
}
