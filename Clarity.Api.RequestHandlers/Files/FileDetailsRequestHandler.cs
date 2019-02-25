namespace Clarity.Api.Files
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class FileDetailsRequestHandler : DetailsRequestHandler<FileDetailsRequest, File, FileModel>
    {
        public FileDetailsRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
