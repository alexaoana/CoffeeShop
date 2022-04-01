using CoffeeShop.Core.Paginate;
using MediatR;

namespace CoffeeShop.Core.Queries.Products
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
        public Filter Filter { get; set; }
    }
}
