namespace Clarity.Api.Files
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class ProductIndexRequestHandler : IndexRequestHandler<FileIndexRequest, File, FileModel>
    {
        public ProductIndexRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
