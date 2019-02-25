namespace Clarity.Api.ProductFiles
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class ProductFileDetailsRequestHandler : DetailsRequestHandler<ProductFileDetailsRequest, ProductFile, ProductFileModel>
    {
        public ProductFileDetailsRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
