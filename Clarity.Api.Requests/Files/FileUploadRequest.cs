namespace Clarity.Api.Files
{
    using Core;
    using Microsoft.AspNetCore.Http;

    public class FileUploadRequest : UploadRequest<Api.File, Api.FileModel>
    {
        public FileUploadRequest(IFormFileCollection files) : base(files)
        {
        }
    }
}
