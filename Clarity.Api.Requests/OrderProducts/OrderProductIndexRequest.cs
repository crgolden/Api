namespace Clarity.Api.OrderProducts
{
    using Core;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class OrderProductIndexRequest : IndexRequest<OrderProduct, OrderProductModel>
    {
        public OrderProductIndexRequest(ModelStateDictionary modelState, DataSourceRequest request) : base(modelState, request)
        {
        }
    }
}
