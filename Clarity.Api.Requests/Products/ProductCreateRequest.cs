namespace Clarity.Api.Products
{
    using Core;

    public class ProductCreateRequest : CreateRequest<Product>
    {
        public ProductCreateRequest(Product product) : base(product)
        {
        }
    }
}
