namespace Clarity.Api.Payments
{
    using Core;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class PaymentIndexRequest : IndexRequest<Payment, PaymentModel>
    {
        public PaymentIndexRequest(ModelStateDictionary modelState, DataSourceRequest request) : base(modelState, request)
        {
        }
    }
}
