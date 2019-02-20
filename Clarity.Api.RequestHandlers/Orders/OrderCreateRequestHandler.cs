namespace Clarity.Api.Orders
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class OrderCreateRequestHandler : CreateRequestHandler<OrderCreateRequest, Order>
    {
        private readonly IPaymentService _paymentService;

        public OrderCreateRequestHandler(DbContext context, IPaymentService paymentService) : base(context)
        {
            _paymentService = paymentService;
        }

        public override async Task<Order> Handle(OrderCreateRequest request, CancellationToken cancellationToken)
        {
            request.Entity.Total = request.Entity.OrderProducts.Sum(x => x.ExtendedPrice);
            if (request.Entity.Payments == null || request.Entity.Payments.All(x => string.IsNullOrEmpty(x.TokenId)))
            {
                return await base.Handle(request, cancellationToken).ConfigureAwait(false);
            }

            foreach (var payment in request.Entity.Payments.Where(x => !string.IsNullOrEmpty(x.TokenId)))
            {
                if (!string.IsNullOrEmpty(request.CustomerCode))
                {
                    payment.CustomerCode = request.CustomerCode;
                }
                else
                {
                    if (string.IsNullOrEmpty(request.Email))
                    {
                        continue;
                    }

                    payment.CustomerCode = await _paymentService
                        .CreateCustomerAsync(request.Email, payment.TokenId)
                        .ConfigureAwait(false);
                    request.CustomerCode = payment.CustomerCode;
                }

                payment.ChargeId = await _paymentService
                    .CaptureAsync(payment.CustomerCode, payment.Amount, payment.Currency, payment.Description)
                    .ConfigureAwait(false);
            }

            return await base.Handle(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
