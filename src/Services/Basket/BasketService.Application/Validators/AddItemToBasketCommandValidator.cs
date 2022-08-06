using BasketService.Application.Commands.Basket;
using FluentValidation;

namespace BasketService.Application.Validators;

public class AddItemToBasketCommandValidator: AbstractValidator<AddItemToBasketCommand>
{
    public AddItemToBasketCommandValidator()
    {
        RuleFor(x => x.BasketId).NotEmpty();
        RuleFor(x => x.ProductId).NotEmpty();
        RuleFor(x => x.Quantity).GreaterThan(0);
    }
}
