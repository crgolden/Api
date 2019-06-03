namespace crgolden.Api.Categories
{
    using Abstractions;

    public class CategoryUpdateRequest : UpdateRequest<Category, CategoryModel>
    {
        public CategoryUpdateRequest(CategoryModel category) : base(category)
        {
        }
    }
}
