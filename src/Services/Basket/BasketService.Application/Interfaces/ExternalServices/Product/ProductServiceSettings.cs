namespace BasketService.Application.Interfaces.ExternalServices.Product
{
    public class ProductServiceSettings
    {
        public string BaseUri { get; set; }
        public Endpoint Endpoint { get; set; }
    }

    public class Endpoint
    {
        public string GetById { get; set; }
    }
}
