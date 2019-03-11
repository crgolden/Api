namespace Clarity.Api.Files
{
    using System.Collections.Generic;
    using Core;
    using Microsoft.AspNetCore.Http;

    public class FileCreateRangeRequest : CreateRangeRequest<IEnumerable<Api.FileModel>, Api.File, Api.FileModel>
    {
        public IFormFileCollection Files { get; set; }

        public FileCreateRangeRequest(IEnumerable<Api.FileModel> files) : base(files)
        {
        }
    }
}
