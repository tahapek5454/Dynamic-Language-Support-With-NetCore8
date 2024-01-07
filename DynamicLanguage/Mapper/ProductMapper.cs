using AutoMapper;
using DynamicLanguage.Context;
using DynamicLanguage.Extensions;
using DynamicLanguage.Models;
using DynamicLanguage.ViewModel;

namespace DynamicLanguage.Mapper
{
    public class ProductMapper: Profile
    {
        public ProductMapper()
        {
            CreateMap<ProductAddVM, Product>();
            CreateMap<Product, ProductGetVM>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(MapFunc.ReturnNameLanguageDynamic))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(MapFunc.ReturnDescriptionLanguageDynamic));
        }
    }
}
