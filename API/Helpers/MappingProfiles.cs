using API.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProdcutDTO>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.Brand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.Type.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
             CreateMap<Address, AddressDto>().ReverseMap();
             CreateMap<CustomerBasketDto, CustomerBasket>();
             CreateMap<BasketItemDto, BasketItem>();
        }
    }
}