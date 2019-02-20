namespace Clarity.Api.Products
{
    using Core;

    public class ProductEditRequest : EditRequest<Product>
    {
        public ProductEditRequest(Product product) : base(product)
        {
        }
    }
}
