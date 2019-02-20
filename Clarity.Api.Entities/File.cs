namespace Clarity.Api
{
    using System;
    using System.Collections.Generic;
    using Core;
    using Newtonsoft.Json;

    public class File : Entity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("fileName")] 
        public string FileName { get; set; }

        [JsonProperty("contentType")]
        public string ContentType { get; set; }

        [JsonProperty("productFiles")]
        public virtual ICollection<ProductFile> ProductFiles { get; set; } = new List<ProductFile>();
    }
}