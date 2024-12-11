using LinkBucket.Attributes;

namespace LinkBucket.Model.GetProductDetails;

public class ProductDetailSkuImage
{
    [Link] public string SmallImage { get; set; } = string.Empty;

    [Link] public string MediumImage { get; set; } = string.Empty;

    [Link] public string LargeImage { get; set; } = string.Empty;

    public int Order { get; set; }
}