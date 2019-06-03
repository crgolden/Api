namespace crgolden.Api.ProductFiles
{
    using System;
    using Abstractions;

    public class ProductFileReadRequest: ReadRequest<ProductFile, ProductFileModel>
    {
        public readonly Guid ProductId;

        public readonly Guid FileId;

        public ProductFileReadRequest(Guid productId, Guid fileId) : base(new object[] { productId, fileId })
        {
            ProductId = productId;
            FileId = fileId;
        }
    }
}
