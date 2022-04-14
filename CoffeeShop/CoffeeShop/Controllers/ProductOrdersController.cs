using AutoMapper;
using CoffeeShop.Core;
using CoffeeShop.Core.Commands.ProductOrders;
using CoffeeShop.Core.DTOs;
using CoffeeShop.Core.Queries.ProductOrders;
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
                Product = productOrderDTO.Product,
                Order = productOrderDTO.Order,
                Quantity = productOrderDTO.Quantity
            });
            return CreatedAtAction(nameof(GetProductOrderById), new { Id = _mapper.Map<ProductOrderDTO, ProductOrder>(productOrder).Id }, productOrder);
        }
    }
}
