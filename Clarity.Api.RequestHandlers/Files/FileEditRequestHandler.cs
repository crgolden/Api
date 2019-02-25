namespace Clarity.Api.Files
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class FileEditRequestHandler : EditRequestHandler<FileEditRequest, File, FileModel>
    {
        public FileEditRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
