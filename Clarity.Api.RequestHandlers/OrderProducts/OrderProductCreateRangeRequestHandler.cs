namespace Clarity.Api.OrderProducts
{
    using System.Collections.Generic;
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class OrderProductCreateRangeRequestHandler : CreateRangeRequestHandler<OrderProductCreateRangeRequest, IEnumerable<OrderProductModel>, OrderProduct, OrderProductModel>
    {
        public OrderProductCreateRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
