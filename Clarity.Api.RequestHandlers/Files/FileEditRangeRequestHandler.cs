namespace Clarity.Api.Files
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class FileEditRangeRequestHandler : EditRangeRequestHandler<FileEditRangeRequest, Api.File, Api.FileModel>
    {
        public FileEditRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
