namespace Clarity.Api
{
    using System;
    using System.Collections.Generic;
    using Core;
    using Newtonsoft.Json;

    public class Cart : Entity
    {
        [JsonProperty("id")]
        public Guid Id { get; private set; }

        [JsonProperty("userId")]
        public Guid? UserId { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("cartProducts")]
        public virtual ICollection<CartProduct> CartProducts { get; set; } = new List<CartProduct>();

        public Cart()
        {
        }

        public Cart(Guid? id = null, Guid? userId = null)
        {
            if (id.HasValue) Id = id.Value;
            if (userId.HasValue) UserId = userId.Value;
        }
    }
}
