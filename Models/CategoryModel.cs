namespace Clarity.Api
{
    using System;
    using Abstractions;
    
    public class CategoryModel : Model
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
