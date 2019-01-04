namespace Cef.API.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
    using Relationships;

    public class File : BaseModel, IFormFile
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        /// <inheritdoc />
        [JsonProperty("contentType")]
        public string ContentType { get; set; }

        /// <inheritdoc />
        [JsonProperty("contentDisposition")]
        public string ContentDisposition { get; set; }

        /// <inheritdoc />
        [NotMapped]
        [JsonIgnore]
        public IHeaderDictionary Headers { get; set; }

        /// <inheritdoc />
        [JsonProperty("length")]
        public long Length { get; set; }

        /// <inheritdoc />
        [JsonProperty("fileName")] 
        public string FileName { get; set; }

        /// <inheritdoc />
        public Stream OpenReadStream()
        {
            return null;
        }

        /// <inheritdoc />
        public void CopyTo(Stream target)
        {
        }

        /// <inheritdoc />
        public Task CopyToAsync(Stream target, CancellationToken cancellationToken = default)
        {
            return null;
        }

        [JsonProperty("productFiles")]
        public virtual ICollection<ProductFile> ProductFiles { get; set; }
    }
}