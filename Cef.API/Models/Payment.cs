namespace Cef.API.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using Core;
    using Newtonsoft.Json;

    [ExcludeFromCodeCoverage]
    public class Payment : BaseModel
    {
        [Required]
        [JsonProperty("userId")]
        public Guid UserId { get; set; }

        [JsonProperty("chargeId")]
        public string ChargeId { get; set; }

        [Required]
        [JsonProperty("orderId")]
        public Guid OrderId { get; set; }

        [JsonIgnore]
        [JsonProperty("order")]
        public virtual Order Order { get; set; }

        [Required]
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [Required]
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [Required]
        [JsonProperty("tokenId")]
        public string TokenId { get; set; }

        [JsonProperty("authorizationCode")]
        public string AuthorizationCode { get; set; }
    }
}