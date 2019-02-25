namespace Clarity.Api.ProductFiles
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class ProductFileEditRequestHandler : EditRequestHandler<ProductFileEditRequest, ProductFile, ProductFileModel>
    {
        public ProductFileEditRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
