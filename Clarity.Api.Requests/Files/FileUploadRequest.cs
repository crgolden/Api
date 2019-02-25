namespace Clarity.Api.Files
{
    using System.Collections.Generic;
    using MediatR;
    using Microsoft.AspNetCore.Http;

    public class FileUploadRequest : IRequest<FileModel[]>
    {
        public readonly ICollection<IFormFile> Files;

        public FileUploadRequest(ICollection<IFormFile> files)
        {
            Files = files;
        }
    }
}
