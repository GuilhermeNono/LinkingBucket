using System.Xml.Serialization;

namespace LinkBucket.Model.Response;

[Serializable]
[XmlRoot(ElementName = "Produtos")]
public class ProductWrapper
{
    [XmlElement(ElementName = "Produto")]
    public List<Product> Products { get; set; } = new();
}
