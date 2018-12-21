namespace Cef.API.Models
{
    using System;
    using System.Collections.Generic;
    using Core.Models;
    using Relationships;

    public class Order : BaseModel
    {
        public Guid UserId { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
