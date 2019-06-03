namespace crgolden.Api.Files
{
    using System;
    using Core.Files;
    using Shared;
    using Microsoft.EntityFrameworkCore;

    public class FileRemoveRequestHandler : FileRemoveRequestHandler<FileRemoveRequest, File, Guid>
    {
        public FileRemoveRequestHandler(
            DbContext context,
            IStorageService storageService) : base(context, storageService)
        {
        }
    }
}
