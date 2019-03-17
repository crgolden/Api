namespace Clarity.Api.Categories
{
    using Abstractions;

    public class CategoryCreateRequest : CreateRequest<Category, CategoryModel>
    {
        public CategoryCreateRequest(CategoryModel category) : base(category)
        {
        }
    }
}
