namespace Clarity.Api
{
    using System;
    using Core;

    public class Payment : Entity
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string ChargeId { get; set; }

        public Guid OrderId { get; set; }

        public virtual Order Order { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public string Description { get; set; }

        public string TokenId { get; set; }

        public string CustomerCode { get; set; }
    }
}
