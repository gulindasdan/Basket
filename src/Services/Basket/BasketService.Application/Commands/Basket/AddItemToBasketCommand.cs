using BasketService.Application.Commands.Basket.Dto;
using BasketService.Application.Interfaces;
using BasketService.Application.Interfaces.ExternalServices.Product;
using Mapster;
using MediatR;

namespace BasketService.Application.Commands.Basket;

public record AddItemToBasketCommand : IRequest<BasketResultDto>
{
    public string BasketId { get; init; }
    public string ProductId { get; init; }
    public int Quantity { get; init; }
}

public class AddItemToBasketCommandHandler : IRequestHandler<AddItemToBasketCommand, BasketResultDto>
{
    private readonly IBasketRepository _basketRepository;
    private readonly IProductService _productService;

    public AddItemToBasketCommandHandler(IBasketRepository basketRepository, IProductService productService)
    {
        _basketRepository = basketRepository;
        _productService = productService;
    }

    public async Task<BasketResultDto> Handle(AddItemToBasketCommand request, CancellationToken cancellationToken)
    {
        var basket = await _basketRepository.GetBasket(request.BasketId, cancellationToken);
        if (basket.Items.Any(x => x.ProductId == request.ProductId))
        {
            await IncreaseItemQuantity(basket, request.ProductId, request.Quantity, cancellationToken);
        }
        else
        {
            await AddItemToBasket(basket, request.ProductId, request.Quantity, cancellationToken);
        }

        var updatedBasket = await _basketRepository.UpdateBasket(basket, cancellationToken);
        return updatedBasket.Adapt<BasketResultDto>();
    }

    private async Task AddItemToBasket(Domain.Entities.Basket basket, string productId, int quantity, CancellationToken cancellationToken)
    {
        var product = await _productService.GetProductById(productId, cancellationToken);
        if (product == null)
            throw new KeyNotFoundException("The specified product is not found.");

        CheckStock(product.Quantity, quantity);

        basket.Items.Add(new Domain.Entities.BasketItem
        {
            ProductId = productId,
            Price = product.Price,
            ProductName = product.Name,
            Quantity = quantity,
            Image = product.Image,
            Link = product.Link
        });
    }

    private async Task IncreaseItemQuantity(Domain.Entities.Basket basket,
                                            string productId,
                                            int quantity,
                                            CancellationToken cancellationToken)
    {
        var product = await _productService.GetProductById(productId, cancellationToken);
        if (product == null)
            throw new KeyNotFoundException("The specified product is not found.");

        var item = basket.Items.First(x => x.ProductId == productId);
        CheckStock(product.Quantity, item.Quantity + quantity);
        item.Quantity += quantity;
    }

    private static void CheckStock(int stock, int quantity)
    {
        if (stock <= quantity)
            throw new InvalidOperationException("The product is out of stock.");
    }
}
