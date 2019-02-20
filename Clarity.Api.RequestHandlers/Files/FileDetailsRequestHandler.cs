namespace Clarity.Api.Files
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class FileDetailsRequestHandler : DetailsRequestHandler<FileDetailsRequest, File>
    {
        public FileDetailsRequestHandler(DbContext context) : base(context)
        {
        }

        public override async Task<File> Handle(FileDetailsRequest request, CancellationToken cancellationToken)
        {
            return await base.Handle(request, cancellationToken);
        }
    }
}
