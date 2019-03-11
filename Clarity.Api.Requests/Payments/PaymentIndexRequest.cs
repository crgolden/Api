namespace Clarity.Api.Payments
{
    using System;
    using Core;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class PaymentIndexRequest : IndexRequest<Payment, PaymentModel>
    {
        public Guid? UserId { get; set; }

        public PaymentIndexRequest(ModelStateDictionary modelState, DataSourceRequest request, Guid? userId = null) : base(modelState, request)
        {
            UserId = userId;
        }
    }
}
