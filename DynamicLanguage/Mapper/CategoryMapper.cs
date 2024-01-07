using AutoMapper;
using DynamicLanguage.Models;
using DynamicLanguage.ViewModel;
using DynamicLanguage.Extensions;

namespace DynamicLanguage.Mapper
{
    public class CategoryMapper: Profile
    {
        public CategoryMapper()
        {
            CreateMap<CategoryAddVM, Category>();
            CreateMap<Category, CategoryGetVM>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom<DynamicLanguageResolver, string>(p=>"Name"))
                .ForMember(dest => dest.Description, opt => opt.MapFromLanguage(opt.DestinationMember));
        }
    }
}
