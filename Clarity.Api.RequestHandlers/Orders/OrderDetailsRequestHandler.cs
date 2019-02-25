namespace Clarity.Api.Orders
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class OrderDetailsRequestHandler : DetailsRequestHandler<OrderDetailsRequest, Order, OrderModel>
    {
        public OrderDetailsRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
