namespace crgolden.Api.Files
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class FileUpdateRequestHandler : UpdateRequestHandler<FileUpdateRequest, File, FileModel>
    {
        public FileUpdateRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
