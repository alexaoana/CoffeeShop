using AutoMapper;
using CoffeeShop.Core.Commands.Products;
using CoffeeShop.Core.DTOs;
using CoffeeShop.Core.Enums;
using CoffeeShop.Core.Paginate;
using CoffeeShop.Core.Queries.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    [Route("")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(Filter filter)
        {
            var result = await _mediator.Send(new GetProductsQuery { Filter = filter });
            return Ok(_mapper.Map<List<ProductDTO>>(result));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomProduct(List<Ingredient> ingredients)
        {
            var result = await _mediator.Send(new CreateCustomProductCommand { Ingredients = ingredients });
            var mappedResult = _mapper.Map<ProductDTO>(result);
            return CreatedAtAction(nameof(GetProductById), new { id = mappedResult.Id }, mappedResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await _mediator.Send(new GetProductQuery { Id = id });
            if (result == null)
                return NotFound();
            return Ok(_mapper.Map<ProductDTO>(result));
        }
    }
}
