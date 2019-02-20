namespace Clarity.Api.Categories
{
    using System.Collections.Generic;
    using Core;

    public class CategoryEditRangeRequest : EditRangeRequest<Category>
    {
        public CategoryEditRangeRequest(IEnumerable<Category> categories) : base(categories)
        {
        }
    }
}
