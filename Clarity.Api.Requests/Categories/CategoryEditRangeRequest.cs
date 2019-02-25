namespace Clarity.Api.Categories
{
    using System.Collections.Generic;
    using Core;

    public class CategoryEditRangeRequest : EditRangeRequest<Category, CategoryModel>
    {
        public CategoryEditRangeRequest(IEnumerable<CategoryModel> categories) : base(categories)
        {
        }
    }
}
