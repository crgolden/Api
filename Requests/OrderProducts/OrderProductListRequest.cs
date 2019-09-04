namespace crgolden.Api.OrderProducts
{
    using System;
    using Abstractions;
    using Microsoft.AspNet.OData.Query;

    public class OrderProductListRequest : ListRequest<OrderProduct, OrderProductModel>
    {
        public Guid? UserId { get; set; }

        public OrderProductListRequest(ODataQueryOptions<OrderProductModel> options) : base(options)
        {
        }
    }
}
