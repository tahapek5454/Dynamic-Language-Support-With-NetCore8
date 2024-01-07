using AutoMapper;
using AutoMapper.Execution;
using DynamicLanguage.Mapper;
using DynamicLanguage.Middlewares;
using Microsoft.AspNetCore.Builder;
using System.Reflection;

namespace DynamicLanguage.Extensions
{
    public static class Extensions
    {
        public static IApplicationBuilder UseLanguage(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<LanguageMiddleware>();
        }

        public static void MapFromLanguage<TSource, TDestination, TMember>(this IMemberConfigurationExpression<TSource, TDestination, TMember> opt, MemberInfo memberInfo)
        {
            opt.MapFrom((s, d) =>
            {
                return MapFunc.ReturnPropertyLanguageDynamic(s, d, memberInfo);
            });
        }
    }
}
