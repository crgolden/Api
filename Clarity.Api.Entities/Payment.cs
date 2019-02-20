namespace Clarity.Api
{
    using System;
    using Core;
    using Newtonsoft.Json;

    public class Payment : Entity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("userId")]
        public Guid UserId { get; set; }

        [JsonProperty("chargeId")]
        public string ChargeId { get; set; }

        [JsonProperty("orderId")]
        public Guid OrderId { get; set; }

        [JsonIgnore]
        public virtual Order Order { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("tokenId")]
        public string TokenId { get; set; }

        [JsonProperty("customerCode")]
        public string CustomerCode { get; set; }
    }
}
