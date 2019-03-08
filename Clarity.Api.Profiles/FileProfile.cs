namespace Clarity.Api
{
    using AutoMapper;

    public class FileProfile : Profile
    {
        public FileProfile()
        {
            CreateMap<FileModel, File>(MemberList.Destination)
                .ForMember(dest => dest.ProductFiles, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}