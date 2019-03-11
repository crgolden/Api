namespace Clarity.Api.Files
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class FileEditRequestHandler : EditRequestHandler<FileEditRequest, Api.File, Api.FileModel>
    {
        public FileEditRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
