using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Core.Abstract.Repository.Paginate
{
    public class Filter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
