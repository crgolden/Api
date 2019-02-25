namespace Clarity.Api.ProductFiles
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class ProductFileIndexRequestHandler : IndexRequestHandler<ProductFileIndexRequest, ProductFile, ProductFileModel>
    {
        public ProductFileIndexRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
