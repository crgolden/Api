namespace Clarity.Api.ProductFiles
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class ProductFileReadRequestHandler : ReadRequestHandler<ProductFileReadRequest, ProductFile, ProductFileModel>
    {
        public ProductFileReadRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
