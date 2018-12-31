namespace Cef.API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Core.Models;
    using Relationships;

    public class Order : BaseModel
    {
        [Required]
        public Guid UserId { get; set; }

        public string ShippingAddress { get; set; }

        [Required]
        public decimal Total { get; set; }

        [Required]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }

        [Required]
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
