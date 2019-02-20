namespace Clarity.Api
{
    using System;
    using Core;
    using Newtonsoft.Json;

    public class OrderProduct : Entity
    {
        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("extendedPrice")]
        public decimal ExtendedPrice => Quantity * Price;

        [JsonProperty("isDownload")]
        public bool IsDownload { get; set; }

        [JsonProperty("thumbnailUri")]
        public string ThumbnailUri { get; set; }

        [JsonProperty("orderId")]
        public Guid OrderId { get; set; }

        [JsonIgnore]
        public virtual Order Order { get; set; }

        [JsonProperty("productId")]
        public Guid ProductId { get; set; }

        [JsonProperty("productName")]
        public string ProductName { get; set; }

        [JsonIgnore]
        public virtual Product Product { get; set; }
    }
}
