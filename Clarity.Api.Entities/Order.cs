namespace Clarity.Api
{
    using System;
    using System.Collections.Generic;
    using Core;
    using Newtonsoft.Json;

    public class Order : Entity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("userId")]
        public Guid UserId { get; set; }

        [JsonProperty("shippingAddress")]
        public Address ShippingAddress { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("orderProducts")]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

        [JsonProperty("payments")]
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
