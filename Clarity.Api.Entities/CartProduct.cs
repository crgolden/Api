namespace Clarity.Api
{
    using System;
    using Core;

    public class CartProduct : Entity
    {
        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal ExtendedPrice => Quantity * Price;

        public bool IsDownload { get; set; }

        public string ThumbnailUri { get; set; }

        public Guid CartId { get; set; }

        public virtual Cart Cart { get; set; }

        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public virtual Product Product {get; set;}
    }
}
