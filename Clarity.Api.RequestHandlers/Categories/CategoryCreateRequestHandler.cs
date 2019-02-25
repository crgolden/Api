namespace Clarity.Api.Categories
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class CategoryCreateRequestHandler : CreateRequestHandler<CategoryCreateRequest, Category, CategoryModel>
    {
        public CategoryCreateRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
