﻿namespace crgolden.Api.Products
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Abstractions;
    using Core;
    using Shared;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;

    public class ProductListRequestHandler : ListRequestHandler<ProductListRequest, Product, ProductModel>
    {
        private readonly IStorageService _storageService;
        private readonly StorageOptions _storageOptions;

        public ProductListRequestHandler(
            DbContext context,
            IMapper mapper,
            IStorageService storageService,
            IOptions<StorageOptions> storageOptions) : base(context, mapper)
        {
            _storageService = storageService;
            _storageOptions = storageOptions.Value;
        }

        public override async Task<DataSourceResult> Handle(ProductListRequest request, CancellationToken token)
        {
            var products = request.Active
                ? Context.Set<Product>().Where(x => x.Active)
                : Context.Set<Product>();
            return await products
                .Include(x => x.ProductFiles)
                .ThenInclude(x => x.File)
                .AsNoTracking()
                .ToDataSourceResultAsync(request.Request, request.ModelState, product =>
                {
                    var model = Mapper.Map<ProductModel>(product);
                    var productFile = product.ProductFiles
                        .SingleOrDefault(x => x.File.ContentType.Contains("image") && x.IsPrimary);
                    if (productFile == null) return model;
                    model.ImageThumbnailUri = productFile.File.GetImageFileUri(_storageService, _storageOptions, true);
                    return model;
                })
                .ConfigureAwait(false);
        }
    }
}
