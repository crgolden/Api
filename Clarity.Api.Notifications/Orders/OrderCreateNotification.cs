namespace Clarity.Api.Orders
{
    using Core;

    public class OrderCreateNotification : CreateNotification<OrderModel>
    {
        public string[] Emails { get; set; }

        public string Origin { get; set; }
    }
}
