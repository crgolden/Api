namespace Clarity.Api.Products
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class ProductCreateRequestHandler : CreateRequestHandler<ProductCreateRequest, Product, ProductModel>
    {
        public ProductCreateRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
