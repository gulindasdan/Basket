using BasketService.API.Models.Basket.Request;
using BasketService.API.Models.Basket.Response;
using BasketService.Application.Commands.Basket;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BasketService.API.Controllers
{
    [ApiController]
    [Route("api/v1/baskets")]
    public class BasketController : ControllerBase
    {
        private readonly ISender _sender;

        public BasketController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Add an item to basket
        /// </summary>
        /// <param name="basketId"></param>
        /// <param name="request"></param>
        /// <returns>BasketResponse</returns>
        [HttpPost("{basketId}")]
        [ProducesResponseType(typeof(BasketResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddItem(string basketId, AddItemToBasketRequest request)
        {
            var basket = await _sender.Send(new AddItemToBasketCommand
            {
                BasketId = basketId,
                ProductId = request.ProductId,
                Quantity = request.Quantity
            });

            if (basket == null)
                return NotFound();

            return Ok(basket.Adapt<BasketResponse>());
        }
    }
}
