namespace crgolden.Api.OrderProducts
{
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class OrderProductDeleteRangeRequestHandler : DeleteRangeRequestHandler<OrderProductDeleteRangeRequest, OrderProduct>
    {
        public OrderProductDeleteRangeRequestHandler(DbContext context) : base(context)
        {
        }
    }
}
