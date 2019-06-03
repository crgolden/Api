namespace crgolden.Api.Products
{
    using Abstractions;

    public class ProductUpdateRequest : UpdateRequest<Product, ProductModel>
    {
        public ProductUpdateRequest(ProductModel product) : base(product)
        {
        }
    }
}
