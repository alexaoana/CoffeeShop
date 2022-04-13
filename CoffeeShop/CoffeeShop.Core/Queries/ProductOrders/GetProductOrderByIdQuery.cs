using CoffeeShop.Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Core.Queries.ProductOrders
{
    public class GetProductOrderByIdQuery : IRequest<ProductOrderDTO>
    {
        public int ProductOrderId { get; set; }
    }
}
