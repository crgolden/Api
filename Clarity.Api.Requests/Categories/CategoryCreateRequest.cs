namespace Clarity.Api.Categories
{
    using Core;

    public class CategoryCreateRequest : CreateRequest<Category>
    {
        public CategoryCreateRequest(Category category) : base(category)
        {
        }
    }
}
