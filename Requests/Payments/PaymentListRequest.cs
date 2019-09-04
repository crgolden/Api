namespace crgolden.Api.Payments
{
    using System;
    using Abstractions;
    using Microsoft.AspNet.OData.Query;

    public class PaymentListRequest : ListRequest<Payment, PaymentModel>
    {
        public readonly Guid? UserId;

        public PaymentListRequest(ODataQueryOptions<PaymentModel> options, Guid? userId = null) : base(options)
        {
            UserId = userId;
        }
    }
}
