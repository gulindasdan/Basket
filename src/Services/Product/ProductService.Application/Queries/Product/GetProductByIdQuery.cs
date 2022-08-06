using Mapster;
using MediatR;
using ProductService.Application.Interfaces.Repositories;
using ProductService.Application.Queries.Product.Dto;

namespace ProductService.Application.Queries.Product
{
    public record GetProductByIdQuery : IRequest<GetProductResultDto>
    {
        public string Id { get; init; }
    }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductResultDto>
    {
        private readonly IRepository<Entities.Product> _repository;

        public GetProductByIdQueryHandler(IRepository<Entities.Product> repository)
        {
            _repository = repository;
        }

        public async Task<GetProductResultDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);
            return product.Adapt<GetProductResultDto>();
        }
    }
}
