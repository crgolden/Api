namespace Clarity.Api
{
    using Core;

    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderModel>();
        }
    }
}
