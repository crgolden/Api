namespace Clarity.Api.Files
{
    using MediatR;
    using Microsoft.AspNetCore.Http;

    public class FileUploadRequest : IRequest<FileModel[]>
    {
        public readonly IFormFileCollection Files;

        public FileUploadRequest(IFormFileCollection files)
        {
            Files = files;
        }
    }
}
