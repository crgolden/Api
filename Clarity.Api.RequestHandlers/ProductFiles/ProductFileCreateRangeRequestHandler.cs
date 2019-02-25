namespace Clarity.Api.ProductFiles
{
    using System.Collections.Generic;
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class ProductFileCreateRangeRequestHandler : CreateRangeRequestHandler<ProductFileCreateRangeRequest, IEnumerable<ProductFileModel>, ProductFile, ProductFileModel>
    {
        public ProductFileCreateRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
