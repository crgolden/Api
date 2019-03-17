namespace Clarity.Api.OrderProducts
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class OrderProductCreateRangeRequestHandler : CreateRangeRequestHandler<OrderProductCreateRangeRequest, OrderProduct, OrderProductModel>
    {
        public OrderProductCreateRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
