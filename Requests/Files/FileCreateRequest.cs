namespace crgolden.Api.Files
{
    using Abstractions;

    public class FileCreateRequest : CreateRequest<File, FileModel>
    {
        public FileCreateRequest(FileModel file) : base(file)
        {
        }
    }
}
