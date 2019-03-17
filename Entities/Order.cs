namespace Clarity.Api
{
    using System;
    using System.Collections.Generic;
    using Abstractions;
    using Core;

    public class Order : Entity
    {
        private readonly List<OrderProduct> _orderProducts;

        private readonly List<Payment> _payments;

        public Guid Id { get; private set; }

        public int Number { get; private set; }

        public Guid UserId { get; set; }

        public Address ShippingAddress { get; set; }

        public decimal? Shipping { get; set; }

        public decimal? Tax { get; set; }

        public decimal Total { get; set; }

        public virtual IReadOnlyCollection<OrderProduct> OrderProducts => _orderProducts;

        public virtual IReadOnlyCollection<Payment> Payments => _payments;

        public Order()
        {
            _orderProducts = new List<OrderProduct>();
            _payments = new List<Payment>();
        }

        public Order(Guid id) : this()
        {
            Id = id;
        }

        public void AddOrderProduct(OrderProduct orderProduct)
        {
            _orderProducts.Add(orderProduct);
        }

        public bool RemoveOrderProduct(OrderProduct orderProduct)
        {
            return _orderProducts.Remove(orderProduct);
        }

        public void AddPayment(Payment payment)
        {
            _payments.Add(payment);
        }

        public bool RemovePayment(Payment payment)
        {
            return _payments.Remove(payment);
        }
    }
}
