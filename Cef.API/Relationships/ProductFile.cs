namespace Cef.API.Relationships
{
    using Core.Relationships;
    using Models;

    public class ProductFile : BaseRelationship<Product, File>
    {
        public string Uri { get; set; }

        public string ContentType { get; set; }

        public bool Primary { get; set; }
    }
}
