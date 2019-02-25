namespace Clarity.Api.Orders
{
    using System;
    using Core;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class OrderIndexRequest : IndexRequest<Order, OrderModel>
    {
        public Guid? UserId { get; set; }

        public OrderIndexRequest(ModelStateDictionary modelState, DataSourceRequest request) : base(modelState, request)
        {
        }
    }
}
