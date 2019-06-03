namespace crgolden.Api
{
    using System;
    using Abstractions;

    public class ProductCategory : Entity
    {
        public Guid ProductId { get; private set; }

        public virtual Product Product { get; private set; }

        public Guid CategoryId { get; private set; }

        public virtual Category Category { get; private set; }

        public ProductCategory(Guid productId, Guid categoryId)
        {
            ProductId = productId;
            CategoryId = categoryId;
        }
    }
}
