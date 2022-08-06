using BasketService.Application.Interfaces.ExternalServices.Product.Response;

namespace BasketService.Application.Interfaces.ExternalServices.Product;

public interface IProductService
{
    Task<ProductServiceResponse> GetProductById(string productId, CancellationToken cancellationToken);
}
