namespace Clarity.Api.Files
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class FileCreateRequestHandler : CreateRequestHandler<FileCreateRequest, Api.File, Api.FileModel>
    {
        public FileCreateRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
