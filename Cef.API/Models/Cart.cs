namespace Cef.API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Core;
    using Newtonsoft.Json;
    using Relationships;

    public class Cart : BaseModel
    {
        [JsonProperty("userId")]
        public Guid? UserId { get; set; }

        [Required]
        [JsonProperty("total")]
        public decimal Total { get; set; }

        [Required]
        [JsonProperty("cartProducts")]
        public virtual ICollection<CartProduct> CartProducts { get; set; }
    }
}
