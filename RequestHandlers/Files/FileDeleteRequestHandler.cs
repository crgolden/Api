namespace Clarity.Api.Files
{
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class FileDeleteRequestHandler : DeleteRequestHandler<FileDeleteRequest, File>
    {
        public FileDeleteRequestHandler(DbContext context) : base(context)
        {
        }
    }
}
