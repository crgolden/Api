namespace Clarity.Api
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.Extensions.Options;

    public class TelerikDemoFilesClient : IDemoFilesClient
    {
        private const string ImagePath = "https://demos.telerik.com/kendo-ui/content/web/foods/";
        private const int Count = 76;
        private readonly HttpClient _httpClient;
        private readonly IStorageService _storageService;
        private readonly string _images;
        private readonly string _thumbnails;

        public TelerikDemoFilesClient(
            HttpClient httpClient,
            IStorageService storageService,
            IOptions<StorageOptions> storageOptions)
        {
            _httpClient = httpClient;
            _storageService = storageService;
            _images = storageOptions.Value.ImageContainer;
            _thumbnails = storageOptions.Value.ThumbnailContainer;
        }

        public async Task<(Uri, long)[]> GetDemoFileUrisAndSizes(CancellationToken token)
        {
            await _storageService.DeleteAllFromStorageAsync(_images, token).ConfigureAwait(false);
            await _storageService.DeleteAllFromStorageAsync(_thumbnails, token).ConfigureAwait(false);
            var uris = new (Uri, long)[Count];
            for (var i = 0; i < Count; i++)
            {
                var file = SeedFiles.Files[i];
                var imageUri = new Uri($"{ImagePath}{i + 1}.jpg");
                var imageData = await _httpClient.GetByteArrayAsync(imageUri);
                var uri = await _storageService.UploadByteArrayToStorageAsync(
                    buffer: imageData,
                    fileName: $"{file.Id}.jpg",
                    token: token);
                uris[i] = (uri, imageData.LongLength);
            }

            return uris;
        }
    }
}
