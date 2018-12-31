namespace Cef.API.Relationships
{
    using System.ComponentModel.DataAnnotations;
    using Core.Relationships;
    using Models;

    public class OrderProduct : BaseRelationship<Order, Product>
    {
        [Required]
        public decimal Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal ExtendedPrice => Quantity * Price;

        [Required]
        public bool IsDownload { get; set; }
    }
}
