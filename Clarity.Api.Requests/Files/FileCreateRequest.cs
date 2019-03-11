namespace Clarity.Api.Files
{
    using Core;

    public class FileCreateRequest : CreateRequest<Api.File, Api.FileModel>
    {
        public FileCreateRequest(Api.FileModel file) : base(file)
        {
        }
    }
}
