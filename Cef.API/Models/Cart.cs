namespace Cef.API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Core.Models;
    using Relationships;

    public class Cart : BaseModel
    {
        public Guid? UserId { get; set; }

        [Required]
        public decimal Total { get; set; }

        [Required]
        public virtual ICollection<CartProduct> CartProducts { get; set; }
    }
}
