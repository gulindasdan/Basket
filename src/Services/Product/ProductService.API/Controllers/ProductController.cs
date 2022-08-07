using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductService.API.Models.Product.Response;
using ProductService.Application.Queries.Product;

namespace ProductService.API.Controllers
{
    [Route("api/v1/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ISender _mediator;

        public ProductController(ISender mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(GetProductsResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetProducts()
        { 
            var products = await _mediator.Send(new GetProductsQuery());
            return Ok(products.Adapt<GetProductsResponse>());
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetProductResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetProductById(string id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery { Id = id });

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product.Adapt<GetProductResponse>());
        }
    }
}
