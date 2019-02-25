namespace Clarity.Api.Products
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class ProductEditRangeRequestHandler : EditRangeRequestHandler<ProductEditRangeRequest, Product, ProductModel>
    {
        public ProductEditRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
