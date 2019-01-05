namespace Cef.API.Models
{
    using System.Collections.Generic;
    using Core;
    using Newtonsoft.Json;
    using Relationships;

    public class File : BaseModel
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("fileName")] 
        public string FileName { get; set; }

        [JsonProperty("contentType")]
        public string ContentType { get; set; }

        [JsonProperty("productFiles")]
        public virtual ICollection<ProductFile> ProductFiles { get; set; }
    }
}