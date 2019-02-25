namespace Clarity.Api.Products
{
    using Core;

    public class ProductEditRequest : EditRequest<Product, ProductModel>
    {
        public ProductEditRequest(ProductModel product) : base(product)
        {
        }
    }
}
