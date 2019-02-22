namespace Clarity.Api
{
    using System;
    using System.Collections.Generic;
    using Core;

    public class Order : Entity
    {
        public Guid Id { get; set; }

        public int Number { get; set; }

        public Guid UserId { get; set; }

        public Address ShippingAddress { get; set; }

        public decimal Total { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
