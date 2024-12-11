using System.Xml.Serialization;

namespace LinkBucket.Model.Response;

[Serializable]
public class ProductImage
{
    [XmlElement(ElementName = "pp")]
    public string Tiny { get; set; } = string.Empty;

    [XmlElement(ElementName = "p")]
    public string Small { get; set; } = string.Empty;

    [XmlElement(ElementName = "m")]
    public string Medium { get; set; } = string.Empty;

    [XmlElement(ElementName = "g")]
    public string Large { get; set; } = string.Empty;

    [XmlElement(ElementName = "gg")]
    public string ExtraLarge { get; set; } = string.Empty;
}
