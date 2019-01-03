namespace Cef.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Core.Services;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using Models;
    using Options;
    using Utilities;

    public class ProductsService : BaseModelService<Product>
    {
        private readonly AzureBlobStorage _azureBlobStorage;

        public ProductsService(
            DbContext context,
            IOptions<StorageOptions> options) : base(context)
        {
            _azureBlobStorage = options.Value.AzureBlobStorage;
        }

#pragma warning disable 1998
        public override async Task<IEnumerable<Product>> Index()
        {
            var products = Context.Set<Product>()
                .Include(x => x.ProductFiles)
                .ThenInclude(x => x.Model2)
                .AsNoTracking();

            if (products.All(x => !x.ProductFiles.Any()))
            {
                return products;
            }

            foreach (var productFile in products.Where(x => x.ProductFiles.Any()).SelectMany(x => x.ProductFiles))
            {
                string containerName = null;
                if (productFile.Uri.Contains(_azureBlobStorage.ImageContainer))
                {
                    containerName = _azureBlobStorage.ImageContainer;
                }
                else if (productFile.Uri.Contains(_azureBlobStorage.ThumbnailContainer))
                {
                    containerName = _azureBlobStorage.ThumbnailContainer;
                }

                if (!string.IsNullOrEmpty(containerName))
                {
                    productFile.Uri += FilesUtility.GetSharedAccessSignature(
                        accountName: _azureBlobStorage.AccountName,
                        accountKey: _azureBlobStorage.AccountKey,
                        containerName: containerName,
                        fileName: productFile.Model2.FileName);
                }
            }

            return products;
        }
#pragma warning restore 1998

        public override async Task<Product> Details(Guid id)
        {
            var product = await Context.Set<Product>()
                .Include(x => x.ProductFiles)
                .ThenInclude(x => x.Model2)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id.Equals(id));

            if (!product.ProductFiles.Any())
            {
                return product;
            }

            foreach (var productFile in product.ProductFiles)
            {
                string containerName = null;
                if (productFile.Uri.Contains(_azureBlobStorage.ImageContainer))
                {
                    containerName = _azureBlobStorage.ImageContainer;
                }
                else if (productFile.Uri.Contains(_azureBlobStorage.ThumbnailContainer))
                {
                    containerName = _azureBlobStorage.ThumbnailContainer;
                }

                if (!string.IsNullOrEmpty(containerName))
                {

                    productFile.Uri += FilesUtility.GetSharedAccessSignature(
                        accountName: _azureBlobStorage.AccountName,
                        accountKey: _azureBlobStorage.AccountKey,
                        containerName: containerName,
                        fileName: productFile.Model2.FileName);
                }
            }

            return product;
        }

        public override async Task<Product> Create(Product model)
        {
            return await base.Create(model);
        }

        public override async Task<List<Product>> CreateRange(List<Product> models)
        {
            return await base.CreateRange(models);
        }

        public override async Task Edit(Product model)
        {
            await base.Edit(model);
        }

        public override async Task EditRange(List<Product> models)
        {
            await base.EditRange(models);
        }

#pragma warning disable 1998
        public override async Task Delete(Guid id)
        {
        }
#pragma warning restore 1998
    }
}
