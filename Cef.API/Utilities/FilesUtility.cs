namespace Cef.API.Utilities
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Blob;

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
