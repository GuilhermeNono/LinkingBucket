using LinkBucket.Model.GetProductDetails;
using Refit;

namespace LinkBucket.Refit.Premios;

public interface IPremiosRepository
{
    [Get("/v2/products/skus/{sku}")]
    public Task<ProductDetailResponse?> GetProductDetails(string sku);
}