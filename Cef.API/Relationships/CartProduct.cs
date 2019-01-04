namespace Cef.API.Relationships
{
    using System.ComponentModel.DataAnnotations;
    using Core;
    using Models;
    using Newtonsoft.Json;

    public class CartProduct : BaseRelationship<Cart, Product>
    {
        [Required]
        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }

        [Required]
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("extendedPrice")]
        public decimal ExtendedPrice => Quantity * Price;

        [Required]
        [JsonProperty("isDownload")]
        public bool IsDownload { get; set; }
    }
}
