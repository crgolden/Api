namespace Clarity.Api
{
    using System;
    using Core;
    using Newtonsoft.Json;

    public class ProductFile : Entity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("contentType")]
        public string ContentType { get; set; }

        [JsonProperty("primary")]
        public bool Primary { get; set; }

        [JsonProperty("productId")]
        public Guid ProductId { get; set; }

        [JsonProperty("productName")]
        public string ProductName { get; set; }

        [JsonIgnore]
        public virtual Product Product { get; set; }

        [JsonProperty("fileId")]
        public Guid FileId { get; set; }

        [JsonProperty("fileName")]
        public string FileName { get; set; }

        [JsonIgnore]
        public virtual File File { get; set; }
    }
}
