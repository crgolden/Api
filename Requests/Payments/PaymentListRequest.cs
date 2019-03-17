namespace Clarity.Api.Payments
{
    using System;
    using Abstractions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class PaymentListRequest : ListRequest<Payment, PaymentModel>
    {
        public readonly Guid? UserId;

        public PaymentListRequest(ModelStateDictionary modelState, DataSourceRequest request, Guid? userId = null) : base(modelState, request)
        {
            UserId = userId;
        }
    }
}
