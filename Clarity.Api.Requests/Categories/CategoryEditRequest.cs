namespace Clarity.Api.Categories
{
    using Core;

    public class CategoryEditRequest : EditRequest<Category, CategoryModel>
    {
        public CategoryEditRequest(CategoryModel category) : base(category)
        {
        }
    }
}
