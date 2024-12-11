using System.Text.Json.Serialization;

namespace LinkBucket.Model.GetProductDetails;

public class ProductDetailResponse
{
    [JsonPropertyName("originalId")] public string Id { get; set; } = string.Empty;

    public string Sku { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ProductDetailBrand Brand { get; set; } = new();
    public List<ProductDetailSku> Skus { get; set; } = [];
    public List<ProductDetailFeature> Features { get; set; } = [];
    public ProductDetailVendor Vendor { get; set; } = new();
    public ProductDetailSubCategory SubCategory { get; set; } = new();
    public bool OnlyCash { get; set; }
    public int FormId { get; set; }
    public int Type { get; set; }
}