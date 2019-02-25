namespace Clarity.Api.Files
{
    using System.Collections.Generic;
    using Core;
    using Microsoft.AspNetCore.Http;

    public class FileCreateRangeRequest : CreateRangeRequest<IEnumerable<FileModel>, File, FileModel>
    {
        public ICollection<IFormFile> Files { get; set; } = new List<IFormFile>();

        public FileCreateRangeRequest(IEnumerable<FileModel> files) : base(files)
        {
        }
    }
}
