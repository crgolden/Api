namespace Clarity.Api.Files
{
    using Abstractions;

    public class FileUpdateRequest : UpdateRequest<File, FileModel>
    {
        public FileUpdateRequest(FileModel file) : base(file)
        {
        }
    }
}
