namespace Clarity.Api
{
    using System;
    using System.Collections.Generic;
    using Core;

    public class Product : Entity
    {
        public Guid Id { get; set; }

        public bool Active { get; set; }

        public string Description { get; set; }

        public bool IsDownload { get; set; }

        public string Name { get; set; }

        public string QuantityPerUnit { get; set; }

        public int ReorderLevel { get; set; }

        public string Sku { get; set; }

        public int UnitsInStock { get; set; }

        public decimal UnitPrice { get; set; }

        public int UnitsOnOrder { get; set; }

        public virtual ICollection<CartProduct> CartProducts { get; set; } = new List<CartProduct>();

        public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

        public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

        public virtual ICollection<ProductFile> ProductFiles { get; set; } = new List<ProductFile>();
    }
}
