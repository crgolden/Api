namespace Clarity.Api.Files
{
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class FileDeleteRequestHandler : DeleteRequestHandler<FileDeleteRequest, File>
    {
        public FileDeleteRequestHandler(DbContext context) : base(context)
        {
        }
    }
}
