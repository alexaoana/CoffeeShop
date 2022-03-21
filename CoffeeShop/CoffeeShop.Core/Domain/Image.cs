using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Core.Domain
{
    public class Image
    {
        public int Id { get; set; }
        public string AzurePath { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
