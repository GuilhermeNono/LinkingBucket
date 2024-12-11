using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace LinkBucket.Helper;

public static class SoapHelper
{
    public static string Serialize<T>(T obj, XmlSerializerNamespaces? namespaces = null)
    {
        namespaces ??= new XmlSerializerNamespaces();

        if(namespaces.Count == 0)
            namespaces.Add("", "");

        XmlWriterSettings settings = new XmlWriterSettings()
        {
            Indent = false,
            OmitXmlDeclaration = true,
            Encoding = Encoding.UTF8
        };

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        using StringWriter stringWriter = new();
        using XmlWriter writer = XmlWriter.Create(stringWriter, settings);
        xmlSerializer.Serialize(writer, obj, namespaces);

        return stringWriter.ToString();
    }

    public static async Task<T?> DeserializeAsync<T>(string xmlData) where T : class
    {
        if (xmlData.Equals(""))
            return null;

        CleanEmptyElements(xmlData, out xmlData);
        using XmlReader reader = XmlReader.Create(new StringReader(xmlData), new XmlReaderSettings { IgnoreWhitespace = true });
        XmlSerializer serializer = new(typeof(T));

        var response = serializer.CanDeserialize(reader) ? (T?)serializer.Deserialize(reader) : null;

        await PropertyHelper.ValidateProperties(response, typeof(T));

        return response;
    }

    private static void CleanEmptyElements(string xml, out string cleanedXml) =>
        cleanedXml = Regex.Replace(xml, @"<(\w+?)>\s*</\1>|<(\w+?)\s*/>", "");
}
