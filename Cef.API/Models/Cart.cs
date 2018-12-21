namespace Cef.API.Models
{
    using System;
    using System.Collections.Generic;
    using Core.Models;
    using Relationships;

    public class Cart : BaseModel
    {
        public Guid UserId { get; set; }

        public virtual ICollection<CartProduct> CartProducts { get; set; }
    }
}
