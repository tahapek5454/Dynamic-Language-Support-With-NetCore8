using AutoMapper;
using System.Reflection;

namespace DynamicLanguage.Mapper
{
    public class DynamicLanguageResolver : IMemberValueResolver<Object, Object, string, string>
    {
        public string Resolve(Object source, Object destination, string destinationPropertyName, string destMember, ResolutionContext context)
        {
            if ((Enums.SystemLanguage)MapFunc._accessor.HttpContext.Items["language"] == Enums.SystemLanguage.tr_TR)
                return source.GetType().GetProperty(destinationPropertyName)?.GetValue(source)?.ToString() ?? ""; // return default

            PropertyInfo[] properties = source.GetType().GetProperties();

            var propertyNames = properties.Select(x => x.Name).ToArray();

            if (!propertyNames.Any())
                return "";

            var sourcePropertyName = propertyNames.FirstOrDefault(x => x.ToUpper() == $"{destinationPropertyName.ToUpper()}_EN" || x.ToUpper() == $"{destinationPropertyName.ToUpper()}EN");

            if (sourcePropertyName is null)
                return source.GetType().GetProperty(destinationPropertyName)?.GetValue(source)?.ToString() ?? ""; // return default

            PropertyInfo? sourceProperty = source.GetType().GetProperty(sourcePropertyName);

            if (sourceProperty is null)
                return source.GetType().GetProperty(destinationPropertyName)?.GetValue(source)?.ToString() ?? ""; // return default

            return sourceProperty.GetValue(source)?.ToString() ?? "";
        }
    }
}
