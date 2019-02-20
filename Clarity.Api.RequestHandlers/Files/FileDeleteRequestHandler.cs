namespace Clarity.Api.Files
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class FileDeleteRequestHandler : DeleteRequestHandler<FileDeleteRequest, File>
    {
        public FileDeleteRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(FileDeleteRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
