namespace Clarity.Api.Products
{
    using System.Collections.Generic;
    using Core;

    public class ProductCreateRangeRequest : CreateRangeRequest<IEnumerable<ProductModel>, Product, ProductModel>
    {
        public ProductCreateRangeRequest(IEnumerable<ProductModel> products) : base(products)
        {
        }
    }
}
