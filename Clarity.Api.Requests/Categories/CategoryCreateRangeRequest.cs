namespace Clarity.Api.Categories
{
    using System.Collections.Generic;
    using Core;

    public class CategoryCreateRangeRequest : CreateRangeRequest<IEnumerable<Category>, Category>
    {
        public CategoryCreateRangeRequest(IEnumerable<Category> categories) : base(categories)
        {
        }
    }
}
