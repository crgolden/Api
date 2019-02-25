namespace Clarity.Api.Files
{
    using System.Collections.Generic;
    using Core;

    public class FileEditRangeRequest : EditRangeRequest<File, FileModel>
    {
        public FileEditRangeRequest(IEnumerable<FileModel> files) : base(files)
        {
        }
    }
}
