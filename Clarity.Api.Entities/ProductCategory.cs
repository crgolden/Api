namespace Clarity.Api
{
    using System;
    using Core;
    using Newtonsoft.Json;

    public class ProductCategory : Entity
    {
        [JsonProperty("productId")]
        public Guid ProductId { get; set; }

        [JsonProperty("productName")]
        public string ProductName { get; set; }

        [JsonIgnore]
        public virtual Product Product { get; set; }

        [JsonProperty("categoryId")]
        public Guid CategoryId { get; set; }

        [JsonProperty("name")]
        public string CategoryName { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }
    }
}
