namespace Clarity.Api.Products
{
    using System.Collections.Generic;
    using Core;

    public class ProductEditRangeRequest : EditRangeRequest<Product, ProductModel>
    {
        public ProductEditRangeRequest(IEnumerable<ProductModel> products) : base(products)
        {
        }
    }
}
