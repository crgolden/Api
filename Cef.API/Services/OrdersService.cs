namespace Cef.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Core.Interfaces;
    using Core.Services;
    using Cef.Core.Utilities;
    using Kendo.Mvc.Extensions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using Models;
    using Options;

    public class OrdersService : BaseModelService<Order>
    {
        private readonly IModelService<Payment> _paymentService;
        private readonly AzureBlobStorage _azureBlobStorage;

        public OrdersService(
            IModelService<Payment> paymentService,
            DbContext context,
            IOptions<StorageOptions> options) : base(context)
        {
            _paymentService = paymentService;
            _azureBlobStorage = options.Value.AzureBlobStorage;
        }

        public override async Task<IEnumerable<Order>> Index()
        {
            return await base.Index();
        }

        public override async Task<Order> Details(Guid id)
        {
            var order = await Context.Set<Order>()
                .Include(x => x.OrderProducts)
                .ThenInclude(x => x.Model2)
                .ThenInclude(x => x.ProductFiles)
                .ThenInclude(x => x.Model2)
                .Include(x => x.Payments)
                .SingleOrDefaultAsync(x => x.Id.Equals(id));
            foreach (var orderProduct in order.OrderProducts.Where(x =>
                x.Model2.ProductFiles.SingleOrDefault(y => y.ContentType.Contains("image") && y.Primary) != null))
            {
                var file = orderProduct.Model2.ProductFiles.Single(z => z.ContentType.Contains("image") && z.Primary).Model2;
                orderProduct.ThumbnailUri = file.Uri.Replace("images/", "thumbnails/") + AzureFilesUtility.GetSharedAccessSignature(
                                               accountName: _azureBlobStorage.AccountName,
                                               accountKey: _azureBlobStorage.AccountKey,
                                               containerName: _azureBlobStorage.ThumbnailContainer,
                                               fileName: file.FileName);
            }

            return order;
        }

        public override async Task<Order> Create(Order model)
        {
            model.Created = model.Created > DateTime.MinValue
                ? model.Created
                : DateTime.Now;
            foreach (var orderProduct in model.OrderProducts)
            {
                orderProduct.Created = model.Created;
            }

            if (model.Payments.Any())
            {
                var payments = new List<Payment>(model.Payments.Count);
                foreach (var modelPayment in model.Payments)
                {
                    var payment = await _paymentService.Create(modelPayment);
                    if (payment == null)
                    {
                        continue;
                    }

                    payment.Created = model.Created;
                    payments.Add(payment);
                }
                model.Payments.Clear();
                model.Payments.AddRange(payments);
            }

            model.Total = model.OrderProducts.Sum(x => x.ExtendedPrice);
            Context.Add(model);
            await Context.SaveChangesAsync();
            return model;
        }

        public override async Task<List<Order>> CreateRange(List<Order> models)
        {
            return await base.CreateRange(models);
        }

        public override async Task Edit(Order model)
        {
            model.Updated = model.Updated ?? DateTime.Now;
            foreach (var orderProduct in model.OrderProducts)
            {
                orderProduct.Updated = model.Updated;
            }

            model.Total = model.OrderProducts.Sum(x => x.ExtendedPrice);
            Context.Entry(model).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public override async Task EditRange(List<Order> models)
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
