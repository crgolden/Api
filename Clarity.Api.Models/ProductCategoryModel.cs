namespace Clarity.Api
{
    using System;
    using Core;

    public class ProductCategoryModel : Model
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public bool ProductActive { get; set; }

        public bool ProductIsDownload { get; set; }

        public string ProductQuantityPerUnit { get; set; }

        public decimal ProductUnitPrice { get; set; }

        public Guid CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
