namespace Clarity.Api
{
    using Core;

    public class FileProfile : Profile
    {
        public FileProfile()
        {
            CreateMap<File, FileModel>();
        }
    }
}