namespace Cef.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Core.Controllers;
    using Core.Interfaces;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Models;
    using Options;
    using Utilities;

    public class ProductsController : BaseModelController<Product>
    {
        private readonly AzureBlobStorage _azureBlobStorage;

        public ProductsController(
            IModelService<Product> service,
            ILogger<ProductsController> logger,
            IOptions<StorageOptions> options)
            : base(service, logger)
        {
            _azureBlobStorage = options.Value.AzureBlobStorage;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Index([DataSourceRequest] DataSourceRequest request = null)
        {
            var products = await Service.Index();
            if (!User.IsInRole("Admin"))
            {
                products = products.Where(x => x.Active);
            }

            return request != null
                ? Ok(await products.ToDataSourceResultAsync(request, ModelState, GetSasTokens))
                : Ok(products);
        }

        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Details([FromRoute] Guid id)
        {
            try
            {
                var product = await Service.Details(id);
                if (product == null)
                {
                    return NotFound(id);
                }

                if (!product.Active && !User.IsInRole("Admin"))
                {
                    return Forbid();
                }

                return Ok(GetSasTokens(product));
            }
            catch (Exception e)
            {
                Logger.LogError(e, e.Message);
                return BadRequest(id);
            }
        }

        [HttpPut("{id:guid}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Edit([FromRoute] Guid id, [FromBody] Product model)
        {
            return await base.Edit(id, model);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> EditRange([FromBody] List<Product> models)
        {
            return await base.EditRange(models);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> Create([FromBody] Product model)
        {
            return await base.Create(model);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType(typeof(List<Product>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> CreateRange([FromBody] List<Product> models)
        {
            return await base.CreateRange(models);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete("{id:guid}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public override async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await base.Delete(id);
        }

        private Product GetSasTokens(Product product)
        {
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
    }
}
