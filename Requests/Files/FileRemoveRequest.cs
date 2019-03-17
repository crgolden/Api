namespace Clarity.Api.Files
{
    using System;
    using Core.Files;

    public class FileRemoveRequest : FileRemoveRequest<Guid>
    {
        public FileRemoveRequest(
            string[] fileNames,
            string containerName,
            string thumbnailContainerName = null,
            Guid[][] keys = null) : base(fileNames, containerName, thumbnailContainerName, keys)
        {
        }
    }
}
