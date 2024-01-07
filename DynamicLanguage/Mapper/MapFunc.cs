using AutoMapper;
using DynamicLanguage.Context;
using DynamicLanguage.Models;
using DynamicLanguage.ViewModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection;

namespace DynamicLanguage.Mapper
{
    public static class MapFunc
    {
        public static IHttpContextAccessor _accessor { get; private set; }
        public static void InitializeHttpContextAccessor(IServiceProvider serviceProvider)
        {
            _accessor = serviceProvider.GetService<IHttpContextAccessor>();
        }

        public static Func<Entity, Object, string> ReturnNameLanguageDynamic = ReturnNameDynamic;
        public static Func<Entity, Object, string> ReturnDescriptionLanguageDynamic = ReturnDescriptionDynamic;
        public static Func<Object, Object, MemberInfo, string> ReturnPropertyLanguageDynamic = ReturnPropertyDynamic;
        private static string ReturnPropertyDynamic(Object entity, Object vm, MemberInfo destinationProperty)
        {
            if ((Enums.SystemLanguage)_accessor.HttpContext.Items["language"] == Enums.SystemLanguage.tr_TR)
                return entity.GetType().GetProperty(destinationProperty.Name)?.GetValue(entity)?.ToString() ?? ""; // return default

            string destionationPropertyName = destinationProperty.Name.ToUpper();

            PropertyInfo[] properties = entity.GetType().GetProperties();

            var propertyNames = properties.Select(x => x.Name).ToArray();

            if (!propertyNames.Any())
                return "";

            var sourcePropertyName = propertyNames.FirstOrDefault(x => x.ToUpper() == $"{destionationPropertyName}_EN" || x.ToUpper() == $"{destionationPropertyName}EN");

            if (sourcePropertyName is null)             
                return entity.GetType().GetProperty(destinationProperty.Name)?.GetValue(entity)?.ToString() ?? ""; // return default

            PropertyInfo? sourceProperty = entity.GetType().GetProperty(sourcePropertyName);

            if (sourceProperty is null)
                return entity.GetType().GetProperty(destinationProperty.Name)?.GetValue(entity)?.ToString() ?? ""; // return default

            return sourceProperty.GetValue(entity)?.ToString() ?? "";

        }
        private static string ReturnNameDynamic(Entity entity, Object vm)
        {
            if ((Enums.SystemLanguage)_accessor.HttpContext.Items["language"] == Enums.SystemLanguage.tr_TR)
                return entity.Name;

            if ((Enums.SystemLanguage)_accessor.HttpContext.Items["language"] == Enums.SystemLanguage.en_EN && !string.IsNullOrEmpty(entity.Name_EN))
                return entity.Name_EN;

            return "Not Registered";
        }
        private static string ReturnDescriptionDynamic(Entity entity, Object vm)
        {
            if ((Enums.SystemLanguage)_accessor.HttpContext.Items["language"] == Enums.SystemLanguage.tr_TR)
                return entity.Description;

            if ((Enums.SystemLanguage)_accessor.HttpContext.Items["language"] == Enums.SystemLanguage.en_EN && !string.IsNullOrEmpty(entity.Name_EN))
                return entity.Description_EN;

            return "Not Registered";
        }


    }

}
