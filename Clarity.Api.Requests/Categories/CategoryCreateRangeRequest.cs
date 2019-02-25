namespace Clarity.Api.Categories
{
    using System.Collections.Generic;
    using Core;

    public class CategoryCreateRangeRequest : CreateRangeRequest<IEnumerable<CategoryModel>, Category, CategoryModel>
    {
        public CategoryCreateRangeRequest(IEnumerable<CategoryModel> categories) : base(categories)
        {
        }
    }
}
