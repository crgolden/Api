namespace crgolden.Api.Files
{
    using Abstractions;
    using Microsoft.AspNet.OData.Query;

    public class FileListRequest : ListRequest<File, FileModel>
    {
        public FileListRequest(ODataQueryOptions<FileModel> options) : base(options)
        {
        }
    }
}
