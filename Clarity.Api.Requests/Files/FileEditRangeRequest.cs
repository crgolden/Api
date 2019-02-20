namespace Clarity.Api.Files
{
    using System.Collections.Generic;
    using Core;

    public class FileEditRangeRequest : EditRangeRequest<File>
    {
        public FileEditRangeRequest(IEnumerable<File> files) : base(files)
        {
        }
    }
}
