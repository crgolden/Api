namespace Clarity.Api.Categories
{
    using System;
    using Core;

    public class CategoryDetailsRequest : DetailsRequest<Category, CategoryModel>
    {
        public readonly Guid CategoryId;

        public CategoryDetailsRequest(Guid categoryId) : base(new object[] { categoryId })
        {
            CategoryId = categoryId;
        }
    }
}
