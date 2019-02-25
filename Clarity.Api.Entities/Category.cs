namespace Clarity.Api
{
    using System;
    using System.Collections.Generic;
    using Core;
    
    public class Category : Entity
    {
        private readonly List<ProductCategory> _productCategories;

        public Guid Id { get; private set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual IReadOnlyCollection<ProductCategory> ProductCategories => _productCategories;

        public Category()
        {
            _productCategories = new List<ProductCategory>();
        }

        public Category(Guid id) : this()
        {
            Id = id;
        }

        public void AddProductCategory(ProductCategory productCategory)
        {
            _productCategories.Add(productCategory);
        }

        public bool RemoveProductCategory(ProductCategory productCategory)
        {
            return _productCategories.Remove(productCategory);
        }
    }
}
