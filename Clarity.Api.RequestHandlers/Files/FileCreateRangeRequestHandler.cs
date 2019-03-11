namespace Clarity.Api.Files
{
    using System.Collections.Generic;
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class FileCreateRangeRequestHandler : CreateRangeRequestHandler<FileCreateRangeRequest, IEnumerable<Api.FileModel>, Api.File, Api.FileModel>
    {
        public FileCreateRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
