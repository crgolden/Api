namespace Clarity.Api
{
    using System;
    using Abstractions;

    public class Payment : Entity
    {
        public Guid Id { get; private set; }

        public Guid UserId { get; set; }

        public string ChargeId { get; set; }

        public Guid OrderId { get; set; }

        public virtual Order Order { get; private set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public string Description { get; set; }

        public string TokenId { get; set; }

        public string CustomerCode { get; set; }

        public Payment()
        {
        }

        public Payment(Guid id) : this()
        {
            Id = id;
        }
    }
}
