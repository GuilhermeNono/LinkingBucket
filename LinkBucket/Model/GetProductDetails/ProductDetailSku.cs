using System.Text.Json.Serialization;

namespace LinkBucket.Model.GetProductDetails;

public class ProductDetailSku
{
    [JsonPropertyName("originalId")] public string Id { get; set; } = string.Empty;

    public string Sku { get; set; } = string.Empty;
    public string Ean { get; set; } = string.Empty;
    public List<ProductDetailSkuImage> Images { get; set; } = [];

    [JsonPropertyName("skuFeatures")] public List<ProductDetailSkuFeature> Features { get; set; } = [];

    public bool? Availability { get; set; }
    public int MinimumPurchase { get; set; }

    [JsonPropertyName("allowedGroupsIds")] public List<string> AllowedGroupIds { get; set; } = [];
}