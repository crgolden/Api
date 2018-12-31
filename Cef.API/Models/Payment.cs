namespace Cef.API.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Core.Models;
    using Newtonsoft.Json;

    public class Payment : BaseModel
    {
        [Required]
        public Guid UserId { get; set; }

        public string ChargeId { get; set; }

        [Required]
        public Guid OrderId { get; set; }

        [JsonIgnore]
        public virtual Order Order { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string Currency { get; set; }

        public string Description { get; set; }

        [Required]
        public string TokenId { get; set; }

        public string AuthorizationCode { get; set; }
    }
}