namespace Clarity.Api.OrderProducts
{
    using System;
    using Core;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class OrderProductIndexRequest : IndexRequest<OrderProduct, OrderProductModel>
    {
        public Guid? UserId { get; set; }

        public OrderProductIndexRequest(ModelStateDictionary modelState, DataSourceRequest request) : base(modelState, request)
        {
        }
    }
}
