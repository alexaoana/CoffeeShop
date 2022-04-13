using CoffeeShop.Core.DTOs;
using MediatR;

namespace CoffeeShop.Core.Queries.Products
{
    public class GetProductByIdQuery : IRequest<ProductDTO>
    {
        public int ProductId { get; set; }
    }
}
