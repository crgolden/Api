namespace Clarity.Api.Categories
{
    using Core;

    public class CategoryCreateRequest : CreateRequest<Category, CategoryModel>
    {
        public CategoryCreateRequest(CategoryModel category) : base(category)
        {
        }
    }
}
