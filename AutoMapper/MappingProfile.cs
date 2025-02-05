using AutoMapper;
using YongdingSun.API.Modles.Domain;
using YongdingSun.API.Modles.DTO;

namespace YongdingSun.API.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Image, ImageDto>().ReverseMap();
        }
    }
}
