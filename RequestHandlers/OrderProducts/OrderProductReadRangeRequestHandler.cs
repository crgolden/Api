namespace Clarity.Api.OrderProducts
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class OrderProductReadRangeRequestHandler : ReadRangeRequestHandler<OrderProductReadRangeRequest, OrderProduct, OrderProductModel>
    {
        public OrderProductReadRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
