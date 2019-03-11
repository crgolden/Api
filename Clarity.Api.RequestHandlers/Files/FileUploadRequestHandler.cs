namespace Clarity.Api.Files
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class FileUploadRequestHandler : UploadRequestHandler<FileUploadRequest, Api.File, Api.FileModel>
    {
        public FileUploadRequestHandler(
            DbContext context,
            IMapper mapper,
            IStorageService storageService) : base(context, mapper, storageService)
        {
        }
    }
}
