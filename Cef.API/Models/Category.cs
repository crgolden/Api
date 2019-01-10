﻿namespace Cef.API.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Core;
    using Newtonsoft.Json;
    using Relationships;

    public class Category : BaseModel
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [Required]
        [JsonProperty("productCategories")]
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}