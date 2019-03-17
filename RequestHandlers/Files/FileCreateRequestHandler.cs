namespace Clarity.Api.Files
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class FileCreateRequestHandler : CreateRequestHandler<FileCreateRequest, File, FileModel>
    {
        public FileCreateRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
