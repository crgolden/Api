namespace Clarity.Api.Products
{
    using System.Collections.Generic;
    using Core;

    public class ProductCreateRangeRequest : CreateRangeRequest<IEnumerable<Product>, Product>
    {
        public ProductCreateRangeRequest(IEnumerable<Product> products) : base(products)
        {
        }
    }
}
