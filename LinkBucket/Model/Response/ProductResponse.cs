using System.Xml.Serialization;

namespace LinkBucket.Model.Response;

[Serializable]
public class ProductResponse
{
    [XmlElement(ElementName = "ConsultarProdutosResponse", Namespace = "urn:Giftty")]
    public ProductResult Response { get; set; } = new();
}
