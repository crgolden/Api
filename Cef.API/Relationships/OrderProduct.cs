namespace Cef.API.Relationships
{
    using Core.Relationships;
    using Models;

    public class OrderProduct : BaseRelationship<Order, Product>
    {
        public decimal Quantity { get; set; }
    }
}
