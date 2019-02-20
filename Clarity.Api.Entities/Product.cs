namespace Clarity.Api
{
    using System;
    using System.Collections.Generic;
    using Core;
    using Newtonsoft.Json;

    public class Product : Entity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("isDownload")]
        public bool IsDownload { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("quantityPerUnit")]
        public string QuantityPerUnit { get; set; }

        [JsonProperty("reorderLevel")]
        public int ReorderLevel { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("unitsInStock")]
        public int UnitsInStock { get; set; }

        [JsonProperty("unitPrice")]
        public decimal UnitPrice { get; set; }

        [JsonProperty("unitsOnOrder")]
        public int UnitsOnOrder { get; set; }

        [JsonProperty("cartProducts")]
        public virtual ICollection<CartProduct> CartProducts { get; set; } = new List<CartProduct>();

        [JsonProperty("orderProducts")]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

        [JsonProperty("productCategories")]
        public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

        [JsonProperty("productFiles")]
        public virtual ICollection<ProductFile> ProductFiles { get; set; } = new List<ProductFile>();
    }
}
