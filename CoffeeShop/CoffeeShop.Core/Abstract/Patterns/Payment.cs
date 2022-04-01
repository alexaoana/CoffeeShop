using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Core.Abstract.Patterns
{
    public interface Payment
    {
        void Pay(decimal price);
    }
}
