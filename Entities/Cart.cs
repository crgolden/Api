namespace crgolden.Api
{
    using System;
    using System.Collections.Generic;
    using Abstractions;

    public class Cart : Entity
    {
        private readonly List<CartProduct> _cartProducts;

        public Guid Id { get; private set; }

        public Guid? UserId { get; set; }

        public virtual IReadOnlyCollection<CartProduct> CartProducts => _cartProducts;

        public Cart()
        {
            _cartProducts = new List<CartProduct>();
        }

        public Cart(Guid id, Guid? userId = null) : this()
        {
            Id = id;
            if (userId.HasValue) UserId = userId.Value;
        }

        public void AddCartProduct(CartProduct cartProduct)
        {
            _cartProducts.Add(cartProduct);
        }

        public bool RemoveCartProduct(CartProduct cartProduct)
        {
            return _cartProducts.Remove(cartProduct);
        }
    }
}
