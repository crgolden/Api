namespace Clarity.Api.Products
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class ProductEditRequestHandler : EditRequestHandler<ProductEditRequest, Product, ProductModel>
    {
        public ProductEditRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
