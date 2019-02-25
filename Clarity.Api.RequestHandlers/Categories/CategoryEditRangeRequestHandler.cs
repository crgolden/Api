namespace Clarity.Api.Categories
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class CategoryEditRangeRequestHandler : EditRangeRequestHandler<CategoryEditRangeRequest, Category, CategoryModel>
    {
        public CategoryEditRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
