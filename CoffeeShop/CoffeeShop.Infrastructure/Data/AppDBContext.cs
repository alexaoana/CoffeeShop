using CoffeeShop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Infrastructure.Data
{
    public class AppDBContext
    {
        public IList<User> Users = new List<User>();
    }
}
