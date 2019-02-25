namespace Clarity.Api.Products
{
    using Core;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class ProductIndexRequest : IndexRequest<Product, ProductModel>
    {
        public bool Active { get; set; }

        public ProductIndexRequest(ModelStateDictionary modelState, DataSourceRequest request) : base(modelState, request)
        {
        }
    }
}
