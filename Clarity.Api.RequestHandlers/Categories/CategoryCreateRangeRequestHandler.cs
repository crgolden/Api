namespace Clarity.Api.Categories
{
    using System.Collections.Generic;
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class CategoryCreateRangeRequestHandler : CreateRangeRequestHandler<CategoryCreateRangeRequest, IEnumerable<CategoryModel>, Category, CategoryModel>
    {
        public CategoryCreateRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
