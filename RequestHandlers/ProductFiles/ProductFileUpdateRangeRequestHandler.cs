namespace Clarity.Api.ProductFiles
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class ProductFileUpdateRangeRequestHandler : UpdateRangeRequestHandler<ProductFileUpdateRangeRequest, ProductFile, ProductFileModel>
    {
        public ProductFileUpdateRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
