using System.Xml.Serialization;

namespace LinkBucket.Model.Response;

[Serializable]
public class ProductDimension
{
    [XmlElement(ElementName = "altura")]
    public decimal Height { get; set; }

    [XmlElement(ElementName = "largura")]
    public decimal Width { get; set; }

    [XmlElement(ElementName =  "profundidade")]
    public decimal Depth { get; set; }

    [XmlElement(ElementName = "peso")]
    public decimal Weight { get; set; }
}
