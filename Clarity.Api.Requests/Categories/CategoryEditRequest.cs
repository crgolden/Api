namespace Clarity.Api.Categories
{
    using Core;

    public class CategoryEditRequest : EditRequest<Category>
    {
        public CategoryEditRequest(Category category) : base(category)
        {
        }
    }
}
