namespace Clarity.Api.ProductFiles
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class ProductFileEditRangeRequestHandler : EditRangeRequestHandler<ProductFileEditRangeRequest, ProductFile, ProductFileModel>
    {
        public ProductFileEditRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
