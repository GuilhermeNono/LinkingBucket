using System.Xml.Serialization;

namespace LinkBucket.Model.Response;

[Serializable]
public class ProductResult
{
    [XmlElement(ElementName = "ConsultarProdutosResult")]
    public string Result { get; set; } = string.Empty;
}
