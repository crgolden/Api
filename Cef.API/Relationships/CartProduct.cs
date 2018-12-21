namespace Cef.API.Relationships
{
    using Core.Relationships;
    using Models;

    public class CartProduct : BaseRelationship<Cart, Product>
    {
        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal ExtendedPrice => Quantity * Price;
    }
}
