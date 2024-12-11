using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace LinkBucket.Converters;

public class CDataConverter : IXmlSerializable
{
    private string _value;

    public CDataConverter()
    {
        _value = string.Empty;
    }

    public CDataConverter(string value)
    {
        _value = value;
    }

    public string Value
    {
        get { return _value; }
        set { _value = value; }
    }

    public XmlSchema? GetSchema() => null;

    public void ReadXml(XmlReader reader)
    {
        _value = reader.ReadElementContentAsString();
    }

    public void WriteXml(XmlWriter writer)
    {
        if (_value != null)
        {
            writer.WriteCData(_value);
        }
    }

    public static implicit operator string(CDataConverter converter)
    {
        return converter.Value;
    }

    public static implicit operator CDataConverter(string value)
    {
        return new CDataConverter(value);
    }
}
