using AutoMapper;
using FloweryGladeAPI.Entities;
using FloweryGladeAPI.Models;

namespace FloweryGladeAPI
{
    public class FloweryGladeMappingProfile : Profile
    {
        public FloweryGladeMappingProfile()
        {
            CreateMap<FlowerShop, FlowerShopDTO>()
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.ZipCode, c => c.MapFrom(s => s.Address.ZipCode))
                .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
                .ForMember(m => m.HouseNumber, c => c.MapFrom(s => s.Address.HouseNo));

            //CreateMap<FlowerDTO, Flowers>();
            CreateMap<Flowers, FlowerDTO>();
            //.ForMember(f => f.FlowerName, fl => fl.MapFrom(l => l.));

            CreateMap<CreateFlowerShopDto, FlowerShop>()
                .ForMember(r => r.Address, c => c.MapFrom(
                    dto => new Address()
                    {
                        City = dto.City,
                        ZipCode = dto.ZipCode,
                        Street = dto.Street,
                        HouseNo = dto.HouseNumber
                    }));

        }
    }
}
