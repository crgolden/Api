namespace Clarity.Api.Files
{
    using Core.Files;
    using Microsoft.AspNetCore.Http;

    public class FileUploadRequest : FileUploadRequest<File, FileModel>
    {
        public FileUploadRequest(IFormFileCollection files) : base(files)
        {
        }
    }
}
