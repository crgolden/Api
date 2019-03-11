namespace Clarity.Api.Files
{
    using Core;

    public class FileEditRequest : EditRequest<Api.File, Api.FileModel>
    {
        public FileEditRequest(Api.FileModel file) : base(file)
        {
        }
    }
}
