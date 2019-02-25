namespace Clarity.Api.Files
{
    using Core;

    public class FileEditRequest : EditRequest<File, FileModel>
    {
        public FileEditRequest(FileModel file) : base(file)
        {
        }
    }
}
