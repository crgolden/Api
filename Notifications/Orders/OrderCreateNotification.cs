namespace crgolden.Api.Orders
{
    using Abstractions;

    public class OrderCreateNotification : CreateNotification<OrderModel>
    {
        public string[] Emails { get; set; }

        public string Origin { get; set; }
    }
}
