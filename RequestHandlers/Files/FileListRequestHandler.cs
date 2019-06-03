namespace crgolden.Api.Files
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class ProductListRequestHandler : ListRequestHandler<FileListRequest, File, FileModel>
    {
        public ProductListRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
