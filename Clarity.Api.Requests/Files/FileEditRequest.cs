namespace Clarity.Api.Files
{
    using Core;

    public class FileEditRequest : EditRequest<File>
    {
        public FileEditRequest(File file) : base(file)
        {
        }
    }
}
