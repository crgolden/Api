namespace Clarity.Api
{
    using System;
    using Core;

    public class ProductFileModel : Model
    {
        public bool IsPrimary { get; set; }

        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public Guid FileId { get; set; }

        public string FileName { get; set; }

        public string FileUri { get; set; }

        public string FileContentType { get; set; }
    }
}
