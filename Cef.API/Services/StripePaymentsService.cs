namespace Cef.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Core.Services;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using Models;
    using Options;
    using Stripe;

    public class StripePaymentsService : BaseModelService<Payment>
    {
        private readonly ChargeService _chargeService;

        public StripePaymentsService(DbContext context, IOptions<PaymentOptions> options) : base(context)
        {
            _chargeService = new ChargeService(options.Value?.Stripe?.SecretKey);
        }

        public override async Task<IEnumerable<Payment>> Index()
        {
            return await base.Index();
        }

        public override async Task<Payment> Details(Guid id)
        {
            return await base.Details(id);
        }

        public override async Task<Payment> Create(Payment model)
        {
            var charge = await _chargeService.CreateAsync(new ChargeCreateOptions
            {
                Amount = (long?) model.Amount * 100,
                Currency = model.Currency,
                Description = model.Description,
                SourceId = model.TokenId
            });
            if (!charge.Paid)
            {
                return null;
            }

            model.ChargeId = charge.Id;
            model.AuthorizationCode = charge.AuthorizationCode;
            return model;
        }

        public override async Task<List<Payment>> CreateRange(List<Payment> models)
        {
            return await base.CreateRange(models);
        }

        public override async Task Edit(Payment model)
        {
            await _chargeService.UpdateAsync(model.ChargeId, new ChargeUpdateOptions
            {
                Description = model.Description
                
            });
            await base.Edit(model);
        }

        public override async Task EditRange(List<Payment> models)
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
