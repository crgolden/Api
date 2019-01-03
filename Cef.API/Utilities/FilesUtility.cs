namespace Cef.API.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Options;

    public static class FilesUtility
    {
        public static bool IsImage(IFormFile file)
        {
            return file.ContentType.Contains("image") || new[] { ".jpg", ".png", ".gif", ".jpeg" }
                       .Any(x => file.FileName.EndsWith(x, StringComparison.OrdinalIgnoreCase));
        }

        public static async Task<Uri> UploadFileToStorage(
            IFormFile file,
            string fileName,
            string accountName,
            string accountKey,
            string containerName)
        {
            using (var stream = file.OpenReadStream())
            {
                var storageCredentials = new StorageCredentials(
                    accountName: accountName,
                    keyValue: accountKey);
                var storageAccount = new CloudStorageAccount(storageCredentials, true);
                var blobClient = storageAccount.CreateCloudBlobClient();
                var container = blobClient.GetContainerReference(containerName);
                var blockBlob = container.GetBlockBlobReference(fileName);
                await blockBlob.UploadFromStreamAsync(stream);
                return blockBlob.Uri;
            }
        }

        public static List<string> GetThumbNailUrls(ICollection<string> fileNames, AzureBlobStorage azureBlobStorage)
        {
            var storageCredentials = new StorageCredentials(
                accountName: azureBlobStorage.AccountName,
                keyValue: azureBlobStorage.AccountKey);
            var storageAccount = new CloudStorageAccount(storageCredentials, true);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(azureBlobStorage.ThumbnailContainer);
            var thumbnails = container.ListBlobs()
                .Where(x => x.StorageUri.PrimaryUri.IsFile)
                .Select(x =>
                {
                    var fileName = Path.GetFileName(x.StorageUri.PrimaryUri.LocalPath);
                    var index = fileName.LastIndexOf('.');
                    var name = fileName.Substring(0, index);
                    return fileNames.Any(y => y.Contains(name))
                        ? new
                        {
                            fileName,
                            x.StorageUri.PrimaryUri
                        }
                        : null;
                }).Where(x => x != null);
            return (from thumbnail in thumbnails
                let blockBlob = container.GetBlockBlobReference(thumbnail.fileName)
                let sasBlobToken = blockBlob.GetSharedAccessSignature(new SharedAccessBlobPolicy
                {
                    SharedAccessStartTime = DateTimeOffset.UtcNow,
                    Permissions = SharedAccessBlobPermissions.Read
                })
                select $"{thumbnail}{sasBlobToken}").ToList();
        }

        public static string GetSharedAccessSignature(
            string accountName,
            string accountKey,
            string containerName,
            string fileName)
        {
            var storageCredentials = new StorageCredentials(
                accountName: accountName,
                keyValue: accountKey);
            var storageAccount = new CloudStorageAccount(storageCredentials, true);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(containerName);
            var blockBlob = container.GetBlockBlobReference(fileName);
            return blockBlob.GetSharedAccessSignature(new SharedAccessBlobPolicy
            {
                SharedAccessStartTime = DateTimeOffset.UtcNow,
                SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddHours(24),
                Permissions = SharedAccessBlobPermissions.Read
            });
        }
    }
}
