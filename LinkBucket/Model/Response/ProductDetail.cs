using System.Xml.Serialization;

namespace LinkBucket.Model.Response;

[Serializable]
public class ProductDetail
{
    [XmlElement(ElementName = "prazo")]
    public string Deadline { get; set; } = string.Empty;

    [XmlElement(ElementName = "validade")]
    public string Validity { get; set; } = string.Empty;

    [XmlElement(ElementName = "utilizacao")]
    public string Use { get; set; } = string.Empty;

    [XmlElement(ElementName = "descricao")]
    public string Description { get; set; } = string.Empty;
}