namespace Clarity.Api
{
    using System;
    using Core;

    public class ProductModel : Model
    {
        public Guid Id { get; set; }

        public bool Active { get; set; }

        public string Description { get; set; }

        public bool IsDownload { get; set; }

        public string Name { get; set; }

        public string QuantityPerUnit { get; set; }

        public int ReorderLevel { get; set; }

        public string Sku { get; set; }

        public string ImageUri { get; set; }

        public string ImageThumbnailUri { get; set; }

        public int UnitsInStock { get; set; }

        public decimal UnitPrice { get; set; }

        public int UnitsOnOrder { get; set; }
    }
}
