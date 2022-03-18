using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Core
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Email { get; set; }
        public int AddressId { get; set; }  
        public Address Address { get; set; }
        public List<Order> Orders { get; set; }
    }
}
