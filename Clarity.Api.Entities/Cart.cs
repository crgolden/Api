namespace Clarity.Api
{
    using System;
    using System.Collections.Generic;
    using Core;

    public class Cart : Entity
    {
        public Guid Id { get; private set; }

        public Guid? UserId { get; set; }

        public decimal Total { get; set; }

        public virtual ICollection<CartProduct> CartProducts { get; set; } = new List<CartProduct>();

        public Cart()
        {
        }

        public Cart(Guid? id = null, Guid? userId = null)
        {
            if (id.HasValue) Id = id.Value;
            if (userId.HasValue) UserId = userId.Value;
        }
    }
}
