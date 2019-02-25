namespace Clarity.Api.Files
{
    using System;
    using Core;

    public class FileDetailsRequest : DetailsRequest<File, FileModel>
    {
        public readonly Guid FileId;

        public FileDetailsRequest(Guid fileId) : base(new object[] { fileId })
        {
            FileId = fileId;
        }
    }
}
