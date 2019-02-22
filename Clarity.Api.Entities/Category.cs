namespace Clarity.Api
{
    using System;
    using System.Collections.Generic;
    using Core;
    
    public class Category : Entity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    }
}
