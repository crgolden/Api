namespace crgolden.Api.Categories
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class CategoryReadRequestHandler : ReadRequestHandler<CategoryReadRequest, Category, CategoryModel>
    {
        public CategoryReadRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
