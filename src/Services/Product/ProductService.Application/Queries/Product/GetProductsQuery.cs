using Mapster;
using MediatR;
using ProductService.Application.Interfaces.Repositories;
using ProductService.Application.Queries.Product.Dto;

namespace ProductService.Application.Queries.Product
{
    public record GetProductsQuery : IRequest<GetProductsResultDto>
    {
    }

    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, GetProductsResultDto>
    {
        private readonly IRepository<Entities.Product> _repository;

        public GetProductsQueryHandler(IRepository<Entities.Product> repository)
        {
            _repository = repository;
        }

        public async Task<GetProductsResultDto> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAsync();
            return new GetProductsResultDto
            {
                Products = products.Adapt<List<GetProductResultDto>>()
            };
        }
    }
}
