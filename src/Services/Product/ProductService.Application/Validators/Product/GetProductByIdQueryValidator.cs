using FluentValidation;
using ProductService.Application.Queries.Product;

namespace ProductService.Application.Validators.Product
{
    public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
