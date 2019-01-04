namespace Cef.API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Core;
    using Newtonsoft.Json;
    using Relationships;

    public class Order : BaseModel
    {
        [Required]
        [JsonProperty("userId")]
        public Guid UserId { get; set; }

        [JsonProperty("shippingAddress")]
        public string ShippingAddress { get; set; }

        [Required]
        [JsonProperty("total")]
        public decimal Total { get; set; }

        [Required]
        [JsonProperty("orderProducts")]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }

        [Required]
        [JsonProperty("payments")]
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
