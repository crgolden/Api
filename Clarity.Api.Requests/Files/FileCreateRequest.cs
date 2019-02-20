namespace Clarity.Api.Files
{
    using Core;

    public class FileCreateRequest : CreateRequest<File>
    {
        public FileCreateRequest(File file) : base(file)
        {
        }
    }
}
