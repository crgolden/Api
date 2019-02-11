namespace Cef.API.Relationships
{
    using System.Diagnostics.CodeAnalysis;
    using Core;
    using Models;
    using Newtonsoft.Json;

    [ExcludeFromCodeCoverage]
    public class ProductFile : BaseRelationship<Product, File>
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("contentType")]
        public string ContentType { get; set; }

        [JsonProperty("primary")]
        public bool Primary { get; set; }
    }
}
