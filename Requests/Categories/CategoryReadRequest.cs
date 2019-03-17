namespace Clarity.Api.Categories
{
    using System;
    using Abstractions;

    public class CategoryReadRequest : ReadRequest<Category, CategoryModel>
    {
        public readonly Guid CategoryId;

        public CategoryReadRequest(Guid categoryId) : base(new object[] { categoryId })
        {
            CategoryId = categoryId;
        }
    }
}
