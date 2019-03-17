namespace Clarity.Api.Products
{
    using Abstractions;

    public class ProductCreateRequest : CreateRequest<Product, ProductModel>
    {
        public ProductCreateRequest(ProductModel product) : base(product)
        {
        }
    }
}
