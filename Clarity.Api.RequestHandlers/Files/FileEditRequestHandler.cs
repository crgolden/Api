namespace Clarity.Api.Files
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class FileEditRequestHandler : EditRequestHandler<FileEditRequest, File>
    {
        public FileEditRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<Unit> Handle(FileEditRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
