using System.Xml.Serialization;
using LinkBucket.Converters;

namespace LinkBucket.Model.Response;

[Serializable]
public class ProductInformation
{
    private StringConverter _key = string.Empty;
    private StringConverter _value = string.Empty;

    [XmlElement("chave")]
    public string Key { get => _key; set => _key = value; }

    [XmlElement("valor")]
    public string Value { get => _value; set => _value = value; }
}
