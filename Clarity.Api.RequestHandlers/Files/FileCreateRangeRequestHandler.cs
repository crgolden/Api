namespace Clarity.Api.Files
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;

    public class FileCreateRangeRequestHandler : CreateRangeRequestHandler<FileCreateRangeRequest, IEnumerable<File>, File>
    {
        private readonly string _imagesContainer;
        private readonly string _thumbnailsContainer;
        private readonly IStorageService _storageService;

        public FileCreateRangeRequestHandler(
            DbContext context,
            IOptions<StorageOptions> storageOptions,
            IStorageService storageService) : base(context)
        {
            _imagesContainer = storageOptions.Value.ImageContainer;
            _thumbnailsContainer = storageOptions.Value.ThumbnailContainer;
            _storageService = storageService;
        }

        public override async Task<IEnumerable<File>> Handle(FileCreateRangeRequest request, CancellationToken cancellationToken)
        {
            if (!request.Files.Any())
            {
                return await base.Handle(request, cancellationToken).ConfigureAwait(false);
            }

            var files = new List<File>();
            var images = request.Files
                .Where(x => x.IsImage() && x.Length > 0)
                .ToDictionary(x =>
                {
                    var index = x.FileName.LastIndexOf('.');
                    var extension = x.FileName.Substring(index);
                    return $"{Guid.NewGuid()}{extension}";
                }, x => x);

            foreach (var (fileName, file) in images)
            {
                var uri = await _storageService.UploadFileToStorageAsync(
                    file: file,
                    fileName: fileName).ConfigureAwait(false);
                files.Add(new File
                {
                    ContentType = file.ContentType,
                    FileName = fileName,
                    Name = file.FileName,
                    Uri = $"{uri}",
                    ProductFiles = new List<ProductFile>()
                });
                files.Add(new File
                {
                    ContentType = file.ContentType,
                    FileName = fileName,
                    Name = file.FileName,
                    Uri = $"{uri}".Replace(
                        oldValue: $"{_imagesContainer}/",
                        newValue: $"{_thumbnailsContainer}/"),
                    ProductFiles = new List<ProductFile>()
                });
            }

            return await base.Handle(new FileCreateRangeRequest(files), cancellationToken).ConfigureAwait(false);
        }
    }
}
