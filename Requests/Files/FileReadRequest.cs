namespace crgolden.Api.Files
{
    using System;
    using Abstractions;

    public class FileReadRequest : ReadRequest<File, FileModel>
    {
        public readonly Guid FileId;

        public FileReadRequest(Guid fileId) : base(new object[] { fileId })
        {
            FileId = fileId;
        }
    }
}
