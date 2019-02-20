namespace Clarity.Api
{
    using System;
    using System.Collections.Generic;
    using Core;
    using Newtonsoft.Json;

    public class Category : Entity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("productCategories")]
        public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    }
}
