namespace crgolden.Api.Files
{
    using AutoMapper;
    using Core.Files;
    using Shared;
    using Microsoft.EntityFrameworkCore;

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
