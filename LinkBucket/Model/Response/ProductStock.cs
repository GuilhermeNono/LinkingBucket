using System.Xml.Serialization;

namespace LinkBucket.Model.Response;

[Serializable]
public class ProductStock
{
    [XmlElement(ElementName = "controle_estoque")]
    public string StockControl { get; set; } = string.Empty;

    [XmlElement(ElementName = "quant_estoque")]
    public int StockQuantity { get; set; }
}
