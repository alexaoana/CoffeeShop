using CoffeeShop.Core.DTOs;
using CoffeeShop.Core.Paginate;
using MediatR;

namespace CoffeeShop.Core.Queries.Products
{
    public class GetProductsQuery : IRequest<IEnumerable<ProductDTO>>
    {
        public Filter Filter { get; set; }
    }
}
