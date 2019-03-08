namespace Clarity.Api.Files
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class FileCreateRangeRequestHandler : CreateRangeRequestHandler<FileCreateRangeRequest, IEnumerable<FileModel>, File, FileModel>
    {
        private readonly IStorageService _storageService;

        public FileCreateRangeRequestHandler(
            DbContext context,
            IMapper mapper,
            IStorageService storageService) : base(context, mapper)
        {
            _storageService = storageService;
        }

        public override async Task<IEnumerable<FileModel>> Handle(FileCreateRangeRequest request, CancellationToken token)
        {
            if (!request.Files.Any()) return await base.Handle(request, token).ConfigureAwait(false);
            var files = new List<FileModel>();
            foreach (var file in request.Files)
            {
                var index = file.FileName.LastIndexOf('.');
                var extension = file.FileName.Substring(index);
                var id = Guid.NewGuid();
                var uri = await _storageService.UploadFileToStorageAsync(
                    file: file,
                    fileName: $"{id}.{extension}",
                    token: token).ConfigureAwait(false);
                files.Add(new FileModel
                {
                    Id = id,
                    ContentType = file.ContentType,
                    Name = file.FileName,
                    Uri = $"{uri}"
                });
            }
            
            return await base.Handle(new FileCreateRangeRequest(files), token).ConfigureAwait(false);
        }
    }
}
