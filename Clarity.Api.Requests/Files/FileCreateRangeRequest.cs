namespace Clarity.Api.Files
{
    using System.Collections.Generic;
    using Core;
    using Microsoft.AspNetCore.Http;

    public class FileCreateRangeRequest : CreateRangeRequest<IEnumerable<FileModel>, File, FileModel>
    {
        public IFormFileCollection Files { get; set; }

        public FileCreateRangeRequest(IEnumerable<FileModel> files) : base(files)
        {
        }
    }
}
