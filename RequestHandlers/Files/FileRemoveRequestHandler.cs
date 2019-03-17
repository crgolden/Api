namespace Clarity.Api.Files
{
    using System;
    using Core.Files;
    using Microsoft.EntityFrameworkCore;
    using Shared;

    public class FileRemoveRequestHandler : FileRemoveRequestHandler<FileRemoveRequest, File, Guid>
    {
        public FileRemoveRequestHandler(
            DbContext context,
            IStorageService storageService) : base(context, storageService)
        {
        }
    }
}
