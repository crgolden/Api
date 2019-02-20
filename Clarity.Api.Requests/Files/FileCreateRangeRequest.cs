namespace Clarity.Api.Files
{
    using System.Collections.Generic;
    using Core;
    using Microsoft.AspNetCore.Http;

    public class FileCreateRangeRequest : CreateRangeRequest<IEnumerable<File>, File>
    {
        public ICollection<IFormFile> Files { get; set; } = new List<IFormFile>();

        public FileCreateRangeRequest(IEnumerable<File> files) : base(files)
        {
        }
    }
}
