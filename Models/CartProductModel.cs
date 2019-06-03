namespace crgolden.Api
{
    using System;
    using Abstractions;

    public class CartProductModel : Model
    {
        public decimal Quantity { get; set; }

        public Guid CartId { get; set; }

        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public bool ProductActive { get; set; }

        public string ProductQuantityPerUnit { get; set; }

        public string ProductImageThumbnailUri { get; set; }

        public bool ProductIsDownload { get; set; }

        public decimal ProductUnitPrice { get; set; }
    }
}
