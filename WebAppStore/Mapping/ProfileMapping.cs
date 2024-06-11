using AutoMapper;
using WebAppStore.Models;
using WebAppStore.ViewModels;

namespace WebAppStore.Mapping
{
    public class ProfileMapping:Profile
    {
        public ProfileMapping()
        {
            CreateMap<Laptop, LaptopViewModel>()
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.BrandName));

            // CreateMap<LaptopViewModel, Laptop>()
            //.ForMember(dest => dest.Brand, opt => opt.Ignore()); 

            //CreateMap<BrandViewModel, Brand>().ForMember(dest => dest.Laptops, opt => opt.Ignore());

            CreateMap<CreateBrandViewModel, Brand>();
        }
    }
}
