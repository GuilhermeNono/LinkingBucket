using System.Xml.Serialization;

namespace LinkBucket.Model.Response;

[Serializable]
public class ProductPhoto
{
    [XmlElement(ElementName = "p")]
    public string Small { get; set; } = string.Empty;

    [XmlElement(ElementName = "m")]
    public string Medium { get; set; } = string.Empty;

    [XmlElement(ElementName = "g")]
    public string Large { get; set; } = string.Empty;
}
