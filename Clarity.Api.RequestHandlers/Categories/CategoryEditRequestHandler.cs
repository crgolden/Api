namespace Clarity.Api.Categories
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class CategoryEditRequestHandler : EditRequestHandler<CategoryEditRequest, Category, CategoryModel>
    {
        public CategoryEditRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
