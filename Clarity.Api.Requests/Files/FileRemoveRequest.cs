namespace Clarity.Api.Files
{
    using System;
    using Core;

    public class FileRemoveRequest : RemoveRequest<Guid>
    {
        public FileRemoveRequest(string[] fileNames, Guid[][] keys = null) : base(fileNames, keys)
        {
        }
    }
}
