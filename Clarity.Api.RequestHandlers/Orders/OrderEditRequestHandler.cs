namespace Clarity.Api.Orders
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class OrderEditRequestHandler : EditRequestHandler<OrderEditRequest, Order, OrderModel>
    {
        public OrderEditRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
