namespace Clarity.Api.OrderProducts
{
    using System;
    using Abstractions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class OrderProductListRequest : ListRequest<OrderProduct, OrderProductModel>
    {
        public Guid? UserId { get; set; }

        public OrderProductListRequest(ModelStateDictionary modelState, DataSourceRequest request) : base(modelState, request)
        {
        }
    }
}
