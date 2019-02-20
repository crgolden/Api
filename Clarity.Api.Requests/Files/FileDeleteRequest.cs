namespace Clarity.Api.Files
{
    using System;
    using Core;

    public class FileDeleteRequest : DeleteRequest
    {
        public readonly Guid FileId;

        public FileDeleteRequest(Guid fileId) : base(new object[] { fileId })
        {
            FileId = fileId;
        }
    }
}
