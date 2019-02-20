namespace Clarity.Api.Files
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class FileCreateRequestHandler : CreateRequestHandler<FileCreateRequest, File>
    {
        public FileCreateRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<File> Handle(FileCreateRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
