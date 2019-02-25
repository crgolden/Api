namespace Clarity.Api
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;

    public class TelerikDemoFilesClient : IDemoFilesClient
    {
        private const string ImagePath = "https://demos.telerik.com/kendo-ui/content/web/foods/";
        private const int Count = 76;
        private readonly HttpClient _httpClient;
        private readonly IStorageService _storageService;

        public TelerikDemoFilesClient(HttpClient httpClient, IStorageService storageService)
        {
            _httpClient = httpClient;
            _storageService = storageService;
        }

        public async Task<Uri[]> GetDemoFileUris(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await _storageService.DeleteAllFromStorageAsync(cancellationToken);
            var uris = new Uri[Count];
            for (var i = 0; i < Count; i++)
            {
                var file = SeedFiles.Files[i];
                var imageUri = new Uri($"{ImagePath}{i + 1}.jpg");
                var imageData = await _httpClient.GetByteArrayAsync(imageUri);
                var uri = await _storageService.UploadByteArrayToStorageAsync(
                    buffer: imageData,
                    fileName: $"{file.Id}.jpg",
                    cancellationToken: cancellationToken);
                uris[i] = uri;
            }

            return uris;
        }
    }
}
