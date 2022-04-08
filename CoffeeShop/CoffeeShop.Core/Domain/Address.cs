namespace CoffeeShop.Core
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
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
