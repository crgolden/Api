namespace Clarity.Api.Categories
{
    using System;
    using Core;

    public class CategoryDetailsRequest : DetailsRequest<Category>
    {
        public readonly Guid CategoryId;

        public CategoryDetailsRequest(Guid categoryId) : base(new object[] { categoryId })
        {
            CategoryId = categoryId;
        }
    }
}
