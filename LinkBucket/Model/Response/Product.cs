using System.Xml.Serialization;
using LinkBucket.Converters;

namespace LinkBucket.Model.Response;

[Serializable]
public class Product
{
    private StringConverter _name = string.Empty;
    private StringConverter _description = string.Empty;
    private StringConverter _categoryName = string.Empty;
    private StringConverter _supplierName = string.Empty;
    private StringConverter _manufactureName = string.Empty;

    [XmlElement(ElementName = "codigo")]
    public int Code { get; set; }

    [XmlElement(ElementName = "fabricanteId")]
    public int ManufacturerId { get; set; }

    [XmlElement(ElementName = "fabricanteNome")]
    public string ManufacturerName { get => _manufactureName; set => _manufactureName = value; }

    [XmlElement(ElementName = "fornecedorId")]
    public int SupplierId { get; set; }

    [XmlElement(ElementName = "fornecedorNome")]
    public string SupplierName { get => _supplierName; set => _supplierName = value; }

    [XmlElement(ElementName = "departamentoId")]
    public int DepartmentId { get; set; }

    [XmlElement(ElementName = "departamentoNome")]
    public string DepartmentName { get; set; } = string.Empty;

    [XmlElement(ElementName = "categoriaId")]
    public int CategoryId { get; set; }

    [XmlElement(ElementName = "categoriaNome")]
    public string CategoryName { get => _categoryName; set => _categoryName = value; }

    [XmlElement(ElementName = "preco")]
    public string Price { get; set; } = string.Empty;

    [XmlElement(ElementName = "precoDe")]
    public string PriceFrom { get; set; } = string.Empty;

    [XmlElement(ElementName = "precoBTD")]
    public string PriceBtd { get; set; } = string.Empty;

    [XmlElement(ElementName = "precoBTDI")]
    public string PriceBtdi { get; set; } = string.Empty;

    [XmlElement(ElementName = "precoBTDIsemFrete")]
    public string PriceBtdiWithoutShipping { get; set; } = string.Empty;

    [XmlElement(ElementName = "taxa")]
    public string Tax { get; set; } = string.Empty;

    [XmlElement(ElementName = "impostosTaxa")]
    public string TaxImpost { get; set; } = string.Empty;

    [XmlElement(ElementName = "desconto")]
    public string Discount { get; set; } = string.Empty;

    [XmlElement(ElementName = "produtoNome")]
    public string Name { get => _name; set => _name = value; }

    [XmlElement(ElementName = "descricao")]
    public string Description { get => _description; set => _description = value; }

    [XmlElement(ElementName = "habilitado")]
    public string Enabled { get; set; } = string.Empty;

    [XmlElement(ElementName = "tipoProduto")]
    public string Type { get; set; } = string.Empty;

    [XmlElement(ElementName = "Fotos")]
    public ProductPhoto? Photos { get; set; }

    [XmlElement(ElementName = "Imagens")]
    public ProductImage? Images { get; set; }

    [XmlElement(ElementName = "Dimensoes")]
    public ProductDimension Dimensions { get; set; } = new();

    [XmlElement(ElementName = "frete")]
    public string Shipping { get; set; } = string.Empty;

    [XmlElement(ElementName = "impostosFrete")]
    public string ShippingTaxes { get; set; } = string.Empty;

    [XmlElement(ElementName = "Estoque")]
    public ProductStock Stock { get; set; } = new();

    [XmlElement(ElementName = "InformacoesAdicionais")]
    public ProductInformationWrapper Informations { get; set; } = new();

    [XmlElement(ElementName = "DetalhesDescricao")]
    public ProductDetail Details { get; set; } = new();
}