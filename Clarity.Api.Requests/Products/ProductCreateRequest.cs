namespace Clarity.Api.Products
{
    using Core;

    public class ProductCreateRequest : CreateRequest<Product, ProductModel>
    {
        public ProductCreateRequest(ProductModel product) : base(product)
        {
        }
    }
}
