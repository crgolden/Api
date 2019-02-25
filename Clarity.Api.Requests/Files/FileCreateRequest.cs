namespace Clarity.Api.Files
{
    using Core;

    public class FileCreateRequest : CreateRequest<File, FileModel>
    {
        public FileCreateRequest(FileModel file) : base(file)
        {
        }
    }
}
