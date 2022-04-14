using AutoMapper;
using CoffeeShop.Core;
using CoffeeShop.Core.Commands.Products;
using CoffeeShop.Core.DTOs;
using CoffeeShop.Core.Enums;
using CoffeeShop.Core.Paginate;
using CoffeeShop.Core.Queries.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ProductsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery]Filter filter)
        {
            var products = await _mediator.Send(new GetProductsQuery { Filter = filter });
            return Ok(products);
        }
        
        [HttpPost]
        [Route("{productId}")]
        public async Task<IActionResult> CreateCustomProduct([FromBody]List<Ingredient> ingredients, int productId)
        {
            var product = await _mediator.Send(new CreateCustomProductCommand 
            { 
                Ingredients = ingredients,
                Product = _mapper.Map<ProductDTO, Product>(await _mediator.Send(new GetProductByIdQuery { ProductId = productId}))
            });
            return CreatedAtAction(nameof(GetProductById), new { id = _mapper.Map<ProductDTO, Product>(product).Id }, product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody]ProductDTO productDTO)
        {
            var product = await _mediator.Send(new CreateProductCommand
            {
                Name = productDTO.Name,
                Description = productDTO.Description,
                CoffeeIntensity = productDTO.CoffeeIntensity,
                Price = productDTO.Price,
                Amount = productDTO.Amount,
                ProductUnit = productDTO.ProductUnit,
                Image = productDTO.Image
            });
            
            return CreatedAtAction(nameof(GetProductById), new { id = _mapper.Map<ProductDTO, Product>(product).Id }, product);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery { ProductId = id });
            if (product == null)
                return NotFound();
            return Ok(product);
        }
    }
}
