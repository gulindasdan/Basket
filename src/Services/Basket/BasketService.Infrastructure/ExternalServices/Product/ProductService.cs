using BasketService.Application.Interfaces.ExternalServices.Product;
using BasketService.Application.Interfaces.ExternalServices.Product.Response;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text.Json;

namespace BasketService.Infrastructure.ExternalServices.Product
{
    public class ProductService : IProductService
    {
        private readonly ProductServiceSettings _settings;
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IOptions<ProductServiceSettings> options, IHttpClientFactory httpClientFactory)
        {
            _settings = options.Value;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ProductServiceResponse> GetProductById(string productId, CancellationToken cancellationToken)
        {
            var requestUri = $"{_settings.BaseUri}/{_settings.Endpoint.GetById}";
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, string.Format(requestUri, productId));
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.SendAsync(requestMessage, cancellationToken);

            if (!responseMessage.IsSuccessStatusCode)
                return null;

            var responseAsString = await responseMessage.Content.ReadAsStringAsync(cancellationToken);

            return JsonSerializer.Deserialize<ProductServiceResponse>(responseAsString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
