using System.Collections;
using System.Reflection;
using LinkBucket.Attributes;

namespace LinkBucket.Helper;

public static class PropertyHelper
{
    public static async Task ValidateProperties<T>(T obj, Type type)
    {
        await VerifyCollectionProperty(obj);

        var propertiesToLink = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        if (propertiesToLink.Length is 0)
            return;

        foreach (var property in propertiesToLink)
            await ValidateLinkAttributeToProperty(obj, property);
    }

    private static async Task VerifyCollectionProperty<T>(T obj)
    {
        if (obj is IEnumerable enumerable)
        {
            var listValues = enumerable as object[] ?? enumerable.Cast<object>().ToArray();

            if (listValues.Length == 0)
                return;

            foreach (var listValue in listValues)
                if (listValue is not null)
                    await ValidateProperties(listValue, listValue.GetType());
        }
    }

    private static async Task ValidateLinkAttributeToProperty<T>(T obj, PropertyInfo property)
    {
        var value = property.GetValue(obj);

        if (property.PropertyType.IsClass && property.PropertyType != typeof(string) && value is not null)
            await ValidateProperties(value, value.GetType());

        var linkAttribute = property.GetCustomAttribute<LinkAttribute>();

        if (linkAttribute is null)
            return;

        if (value is not string propertyValue)
            return;

        if (!Uri.TryCreate(propertyValue, UriKind.Absolute, out var uri))
            return;

        var newValue = new LinkedBucket.LinkBucket
        {
            BucketOption = linkAttribute.BucketOption,
            DestinationUri = uri
        };

        var internalS3Uri = await newValue.GetInternalS3LinkAsync();

        if (internalS3Uri is null)
            return;

        property.SetValue(obj, internalS3Uri);
    }

}