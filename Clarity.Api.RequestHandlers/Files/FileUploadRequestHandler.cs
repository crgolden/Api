namespace Clarity.Api.Files
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Core;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class FileUploadRequestHandler : IRequestHandler<FileUploadRequest, FileModel[]>
    {
        private readonly DbContext _context;
        private readonly IMapper _mapper;
        private readonly IStorageService _storageService;

        public FileUploadRequestHandler(DbContext context, IMapper mapper, IStorageService storageService)
        {
            _context = context;
            _mapper = mapper;
            _storageService = storageService;
        }

        public async Task<FileModel[]> Handle(FileUploadRequest request, CancellationToken token)
        {
            if (!request.Files.Any()) return new FileModel[0];
            var tasks = request.Files.Select(async x =>
                await x.ToFileAsync(_storageService, token).ConfigureAwait(false));
            var files = await Task.WhenAll(tasks).ConfigureAwait(false);
            _context.Set<File>().AddRange(files);
            await _context.SaveChangesAsync(token).ConfigureAwait(false);
            return _mapper.Map<FileModel[]>(files);
        }
    }
}
