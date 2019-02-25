namespace Clarity.Api.OrderProducts
{
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class OrderProductDeleteRequestHandler : DeleteRequestHandler<OrderProductDeleteRequest, OrderProduct>
    {
        public OrderProductDeleteRequestHandler(DbContext context) : base(context)
        {
        }
    }
}
