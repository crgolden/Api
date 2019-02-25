namespace Clarity.Api.Orders
{
    using Core;

    public class OrderCreateNotification : CreateNotification<OrderModel>
    {
        public string UserEmail { get; set; }
    }
}
