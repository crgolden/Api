namespace Cef.API.Options
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class StorageOptions
    {
        public AzureBlobStorage AzureBlobStorage { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class AzureBlobStorage
    {
        public string AccountName { get; set; }

        public string ImageContainer { get; set; }

        public string ThumbnailContainer { get; set; }

        public string AccountKey { get; set; }
    }
}