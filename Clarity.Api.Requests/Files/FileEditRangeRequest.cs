namespace Clarity.Api.Files
{
    using System.Collections.Generic;
    using Core;

    public class FileEditRangeRequest : EditRangeRequest<Api.File, Api.FileModel>
    {
        public FileEditRangeRequest(IEnumerable<Api.FileModel> files) : base(files)
        {
        }
    }
}
