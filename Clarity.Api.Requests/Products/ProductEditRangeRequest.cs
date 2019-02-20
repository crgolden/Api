namespace Clarity.Api.Products
{
    using System.Collections.Generic;
    using Core;

    public class ProductEditRangeRequest : EditRangeRequest<Product>
    {
        public ProductEditRangeRequest(IEnumerable<Product> products) : base(products)
        {
        }
    }
}
