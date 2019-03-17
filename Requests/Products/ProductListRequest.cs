namespace Clarity.Api.Products
{
    using Abstractions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class ProductListRequest : ListRequest<Product, ProductModel>
    {
        public bool Active { get; set; }

        public ProductListRequest(ModelStateDictionary modelState, DataSourceRequest request) : base(modelState, request)
        {
        }
    }
}
