namespace Clarity.Api.Categories
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class CategoryListRequestHandler : ListRequestHandler<CategoryListRequest, Category, CategoryModel>
    {
        public CategoryListRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
