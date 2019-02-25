namespace Clarity.Api
{
    using System;
    using Core;

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
