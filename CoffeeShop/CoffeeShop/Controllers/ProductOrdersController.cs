using AutoMapper;
using CoffeeShop.Core;
using CoffeeShop.Core.Commands.ProductOrders;
using CoffeeShop.Core.Commands.Products;
using CoffeeShop.Core.DTOs;
using CoffeeShop.Core.Queries.Orders;
using CoffeeShop.Core.Queries.ProductOrders;
using CoffeeShop.Core.Queries.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOrdersController : ControllerBase
    {
        private IMapper _mapper;
        private IMediator _mediator;
        public ProductOrdersController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProductOrderById(int id)
        {
            var productOrder = _mediator.Send(new GetProductOrderByIdQuery { ProductOrderId = id });
            if (productOrder == null)
                return NotFound();
            return Ok(productOrder);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateProductOrder([FromBody]ProductOrderDTO productOrderDTO)
        {
            var productOrder = await _mediator.Send(new CreateProductOrderCommand
            {
                ProductId = productOrderDTO.ProductId,
                OrderId = productOrderDTO.OrderId,
                Quantity = productOrderDTO.Quantity,
                Ingredients = productOrderDTO.Ingredients
            });
            return CreatedAtAction(nameof(GetProductOrderById), new { Id = _mapper.Map<ProductOrderDTO, ProductOrder>(productOrder).Id }, productOrder);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProductOrder(int id)
        {
            var productOrder = await _mediator.Send(new DeleteProductOrderCommand { ProductOrderId = id});
            return Ok(productOrder);
        }
    }
}
