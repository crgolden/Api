namespace Cef.API.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Core;
    using Newtonsoft.Json;
    using Relationships;

    public class Product : BaseModel
    {
        [Required]
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [Required]
        [JsonProperty("unitPrice")]
        public decimal UnitPrice { get; set; }

        [Required]
        [JsonProperty("quantityPerUnit")]
        public string QuantityPerUnit { get; set; }

        [JsonProperty("unitsInStock")]
        public int UnitsInStock { get; set; }

        [JsonProperty("unitsOnOrder")]
        public int UnitsOnOrder { get; set; }

        [JsonProperty("reorderLevel")]
        public int ReorderLevel { get; set; }

        [Required]
        [JsonProperty("isDownload")]
        public bool IsDownload { get; set; }

        [JsonProperty("cartProducts")]
        public virtual ICollection<CartProduct> CartProducts { get; set; }

        [JsonProperty("orderProducts")]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }

        [JsonProperty("productCategories")]
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }

        [JsonProperty("productFiles")]
        public virtual ICollection<ProductFile> ProductFiles { get; set; }
    }
}
