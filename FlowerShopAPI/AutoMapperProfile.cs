using AutoMapper;
using Domain.Models;
using Shared.Dtos;

namespace FlowerShopAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, CatalogProductsDto>().ForMember(opt => opt.ImageUrl, opt => opt.MapFrom(e => e.ImagePaths.First().Path));
            CreateMap<CreateProductDto, Product>().ForMember(opt => opt.ImagePaths, opt => opt.MapFrom(e => e.Files)).PreserveReferences();
            CreateMap<string, Image>().ForMember(opt => opt.Path, opt => opt.MapFrom(e => e));
            CreateMap<FormFile, Image>().ForMember(opt => opt.Path, opt => opt.MapFrom(e => e));

            CreateMap<int, ProductFlowerType>().ForMember(opt => opt.Id, opt => opt.MapFrom(e => e));
            CreateMap<int, ProductAppointment>().ForMember(opt => opt.Id, opt => opt.MapFrom(e => e));

            CreateMap<Product, ProductCardDto>().ForMember(opt => opt.Images, opt => opt.MapFrom(e => e.ImagePaths))
                                                .ForMember(opt => opt.Type, opt => opt.MapFrom(e => e.Type.Name));

            CreateMap<ProductAppointment, string>().ConstructUsing(x => x.Name);
            CreateMap<ProductFlowerType, string>().ConstructUsing(x => x.Name);
            CreateMap<ProductType, string>().ConstructUsing(x => x.Name);
            CreateMap<Image, string>().ConstructUsing(x => x.Path);
        }
    }
}