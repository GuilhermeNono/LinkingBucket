using System.Reflection;
using LinkBucket.Helper;
using Refit;

namespace LinkBucket.Refit.Serializer;

public class ContentSerializer : IHttpContentSerializer
{
    private readonly SystemTextJsonContentSerializer _serializer = new();

    public HttpContent ToHttpContent<T>(T item)
    {
        return _serializer.ToHttpContent(item);
    }

    public async Task<T?> FromHttpContentAsync<T>(HttpContent content,
        CancellationToken cancellationToken = new())
    {
        var result = await _serializer.FromHttpContentAsync<T>(content, cancellationToken);

        var type = typeof(T);

        await PropertyHelper.ValidateProperties(result, type);

        return result;
    }


    public string? GetFieldNameForProperty(PropertyInfo propertyInfo)
    {
        return _serializer.GetFieldNameForProperty(propertyInfo);
    }
}