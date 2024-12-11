using LinkBucket.Model.GetProductDetails;
using LinkBucket.Refit.Serializer;
using LinkBucket.SecretVariables;
using Refit;

namespace LinkBucket.Refit.Premios;

public class PremiosService
{
    private readonly IPremiosRepository _premiosRepository;

    public PremiosService()
    {
        _premiosRepository = RestService.For<IPremiosRepository>(new HttpClient(new PremiosHandler())
            {
                BaseAddress = new Uri(PremiosVariables.Root)
            },
            new RefitSettings
            {
                ContentSerializer = new ContentSerializer()
            });
    }

    public async Task<ProductDetailResponse?> GetProductDetail(string sku)
    {
        return await _premiosRepository.GetProductDetails(sku);
    }
}