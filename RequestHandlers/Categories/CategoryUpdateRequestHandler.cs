namespace Clarity.Api.Categories
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class CategoryUpdateRequestHandler : UpdateRequestHandler<CategoryUpdateRequest, Category, CategoryModel>
    {
        public CategoryUpdateRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
