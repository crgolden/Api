namespace Clarity.Api.Categories
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class CategoryDetailsRequestHandler : DetailsRequestHandler<CategoryDetailsRequest, Category, CategoryModel>
    {
        public CategoryDetailsRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
