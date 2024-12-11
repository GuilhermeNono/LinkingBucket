namespace LinkBucket.Model.GetProductDetails;

public class ProductDetailVendor
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LogoUrl { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
}