namespace Clarity.Api.ProductFiles
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class ProductFileCreateRequestHandler : CreateRequestHandler<ProductFileCreateRequest, ProductFile, ProductFileModel>
    {
        public ProductFileCreateRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
