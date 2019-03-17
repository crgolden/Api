namespace Clarity.Api.Files
{
    using AutoMapper;
    using Core.Files;
    using Microsoft.EntityFrameworkCore;
    using Shared;

    public class FileUploadRequestHandler : FileUploadRequestHandler<FileUploadRequest, File, FileModel>
    {
        public FileUploadRequestHandler(
            DbContext context,
            IMapper mapper,
            IStorageService storageService) : base(context, mapper, storageService)
        {
        }
    }
}
