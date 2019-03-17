namespace Clarity.Api.OrderProducts
{
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class OrderProductDeleteRequestHandler : DeleteRequestHandler<OrderProductDeleteRequest, OrderProduct>
    {
        public OrderProductDeleteRequestHandler(DbContext context) : base(context)
        {
        }
    }
}
