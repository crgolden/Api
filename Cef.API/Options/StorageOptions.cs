namespace Cef.API.Options
{
    public class StorageOptions
    {
        public AzureBlobStorage AzureBlobStorage { get; set; }
    }

    public class AzureBlobStorage
    {
        public string AccountName { get; set; }

        public string ImageContainer { get; set; }

        public string ThumbnailContainer { get; set; }

        public string AccountKey { get; set; }
    }
}