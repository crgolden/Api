namespace Clarity.Api
{
    using Core;

    public static class FileExtensions
    {
        public static string GetImageFileUri(
            this File file,
            IStorageService storageService,
            StorageOptions options,
            bool thumbnail = false)
        {
            var containerName = thumbnail ? options.ThumbnailContainer : options.ImageContainer;
            var uri = thumbnail
                ? file.Uri.Replace($"{options.ImageContainer}/", $"{options.ThumbnailContainer}/")
                : file.Uri;
            var index = file.Name.LastIndexOf('.');
            var extension = file.Name.Substring(index + 1);
            var fileName = $"{file.Id}.{extension}";
            var sharedAccessSignature = storageService.GetSharedAccessSignature(fileName, containerName);
            return $"{uri}{sharedAccessSignature}";
        }
    }
}
