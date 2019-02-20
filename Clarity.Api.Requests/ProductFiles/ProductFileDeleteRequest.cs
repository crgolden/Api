namespace Clarity.Api.ProductFiles
{
    using System;
    using Core;

    public class ProductFileDeleteRequest : DeleteRequest
    {
        public readonly Guid ProductId;

        public readonly Guid FileId;

        public ProductFileDeleteRequest(Guid productId, Guid fileId) : base(new object[] { productId, fileId })
        {
            ProductId = productId;
            FileId = fileId;
        }
    }
}
