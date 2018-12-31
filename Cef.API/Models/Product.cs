namespace Cef.API.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Core.Models;
    using Relationships;

    public class Product : BaseModel
    {
        [Required]
        public bool Active { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string PictureFileName { get; set; }

        public string PictureUri { get; set; }

        [Required]
        public bool IsDownload { get; set; }

        public virtual ICollection<CartProduct> CartProducts { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
