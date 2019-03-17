namespace Clarity.Api.ProductFiles
{
    using Abstractions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class ProductFileListRequest : ListRequest<ProductFile, ProductFileModel>
    {
        public ProductFileListRequest(ModelStateDictionary modelState, DataSourceRequest request) : base(modelState, request)
        {
        }
    }
}
