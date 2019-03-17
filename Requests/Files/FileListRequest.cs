namespace Clarity.Api.Files
{
    using Abstractions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class FileListRequest : ListRequest<File, FileModel>
    {
        public FileListRequest(ModelStateDictionary modelState, DataSourceRequest request) : base(modelState, request)
        {
        }
    }
}
