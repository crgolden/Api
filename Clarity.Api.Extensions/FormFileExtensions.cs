﻿namespace Clarity.Api
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.AspNetCore.Http;

    public static class FormFileExtensions
    {
        public static async Task<File> ToFileAsync(
            this IFormFile file,
            IStorageService storageService,
            CancellationToken token)
        {
            var index = file.FileName.LastIndexOf('.');
            var extension = file.FileName.Substring(index);
            var id = Guid.NewGuid();
            var uri = await storageService.UploadFileToStorageAsync(
                file: file,
                fileName: $"{id}{extension}",
                token: token).ConfigureAwait(false);
            return new File(id)
            {
                ContentType = file.ContentType,
                Name = file.FileName,
                Uri = $"{uri}"
            };
        }
    }
}
