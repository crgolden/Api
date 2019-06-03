namespace crgolden.Api.Files
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class FileReadRequestHandler : ReadRequestHandler<FileReadRequest, File, FileModel>
    {
        public FileReadRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
