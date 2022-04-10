using CoffeeShop.Core.DTOs;
using MediatR;

namespace CoffeeShop.Core.Queries.Products
{
    public class GetProductQuery : IRequest<ProductDTO>
    {
        public int Id { get; set; }
    }
}
