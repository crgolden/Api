namespace Clarity.Api.ProductFiles
{
    using System;
    using Core;

    public class ProductFileDetailsRequest: DetailsRequest<ProductFile, ProductFileModel>
    {
        public readonly Guid ProductId;

        public readonly Guid FileId;

        public ProductFileDetailsRequest(Guid productId, Guid fileId) : base(new object[] { productId, fileId })
        {
            ProductId = productId;
            FileId = fileId;
        }
    }
}
