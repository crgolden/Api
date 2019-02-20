namespace Clarity.Api.Files
{
    using Core;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class FileIndexRequest : IndexRequest
    {
        public FileIndexRequest(ModelStateDictionary modelState = null, DataSourceRequest request = null)
            : base(modelState, request)
        {
        }
    }
}
