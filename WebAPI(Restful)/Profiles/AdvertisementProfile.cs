using AutoMapper;
using WebAPI_Restful_.Data;
using WebAPI_Restful_.DTO;

namespace WebAPI_Restful_.Profiles
{
    public class AdvertisementProfile : Profile
    {
        public AdvertisementProfile()
        {
            //ForAllMembers()?
            CreateMap<AdvertisementDTO, Advertisement>()
                .ForMember(m => m.Title, opt => opt.MapFrom(src => src.Title))
                .ReverseMap();

            CreateMap<AdvertisementDTO, Advertisement>()
                .ForMember(m => m.Author, opt => opt.MapFrom(src => src.Author))
                .ReverseMap();

            CreateMap<AdvertisementDTO, Advertisement>()
                .ForMember(m => m.CreateDate, opt => opt.MapFrom(src => src.CreateDate))
                .ReverseMap();

            CreateMap<AdvertisementDTO, Advertisement>()
                .ForMember(m => m.Description, opt => opt.MapFrom(src => src.Description))
                .ReverseMap();
        }
    }
}
