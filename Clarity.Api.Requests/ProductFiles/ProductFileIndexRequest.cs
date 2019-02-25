namespace Clarity.Api.ProductFiles
{
    using Core;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class ProductFileIndexRequest : IndexRequest<ProductFile, ProductFileModel>
    {
        public ProductFileIndexRequest(ModelStateDictionary modelState, DataSourceRequest request) : base(modelState, request)
        {
        }
    }
}
