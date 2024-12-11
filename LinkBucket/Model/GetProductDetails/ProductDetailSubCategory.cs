namespace LinkBucket.Model.GetProductDetails;

public class ProductDetailSubCategory
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ProductDetailSubCategory? Category { get; set; }
}