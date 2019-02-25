namespace Clarity.Api.Products
{
    using System.Collections.Generic;
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class ProductCreateRangeRequestHandler
        : CreateRangeRequestHandler<ProductCreateRangeRequest, IEnumerable<ProductModel>, Product, ProductModel>
    {
        public ProductCreateRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
