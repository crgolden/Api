namespace Clarity.Api
{
    using System;
    using Core;

    public class ProductCategory : Entity
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public virtual Product Product { get; set; }

        public Guid CategoryId { get; set; }

        public string CategoryName { get; set; }

        public virtual Category Category { get; set; }
    }
}
