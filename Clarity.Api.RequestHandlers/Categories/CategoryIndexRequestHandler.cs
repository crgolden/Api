namespace Clarity.Api.Categories
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class CategoryIndexRequestHandler : IndexRequestHandler<CategoryIndexRequest, Category, CategoryModel>
    {
        public CategoryIndexRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
