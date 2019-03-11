namespace Clarity.Api.Files
{
    using System;
    using Core;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;

    public class FileRemoveRequestHandler : RemoveRequestHandler<FileRemoveRequest, Api.File, Guid>
    {
        public FileRemoveRequestHandler(
            DbContext context,
            IStorageService storageService,
            IOptions<StorageOptions> storageOptions) : base(context, storageService, storageOptions)
        {
        }
    }
}
