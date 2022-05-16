using AutoMapper;
using WebAPI_Restful_.Data;
using WebAPI_Restful_.DTO;

namespace WebAPI_Restful_.Profiles
{
    public class AdvertisementProfile : Profile
    {
        public AdvertisementProfile()
        {
            
            CreateMap<AdvertisementDTO, Advertisement>()
                //.ForMember(m => m.Title, opt => opt.MapFrom(src => src.Title))
                .ReverseMap();

            CreateMap<AdvertisementsDTO, Advertisement>()
                .ReverseMap();

            CreateMap<CreateAdvertisement, Advertisement>()
                .ReverseMap();

            CreateMap<UpdateAdvertisement, Advertisement>()
                .ReverseMap();
        }
    }
}
