using System.Xml.Serialization;

namespace LinkBucket.Model.Response;

[Serializable]
public class ProductInformationWrapper
{
    [XmlElement("Informacao")]
    public List<ProductInformation> Items { get; set; } = [];
}
