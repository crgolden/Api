namespace Clarity.Api.OrderProducts
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class OrderProductEditRangeRequestHandler : EditRangeRequestHandler<OrderProductEditRangeRequest, OrderProduct, OrderProductModel>
    {
        public OrderProductEditRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
