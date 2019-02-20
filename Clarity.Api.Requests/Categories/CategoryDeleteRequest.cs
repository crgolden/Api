namespace Clarity.Api.Categories
{
    using System;
    using Core;

    public class CategoryDeleteRequest : DeleteRequest
    {
        public readonly Guid CategoryId;

        public CategoryDeleteRequest(Guid categoryId) : base(new object[] { categoryId })
        {
            CategoryId = categoryId;
        }
    }
}
