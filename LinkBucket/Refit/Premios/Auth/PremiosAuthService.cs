using LinkBucket.Model;
using LinkBucket.Model.GetToken;
using LinkBucket.SecretVariables;
using Refit;

namespace LinkBucket.Refit.Premios.Auth;

public class PremiosAuthService
{
    private readonly IPremiosAuthRepository _premiosAuthRepository;

    public PremiosAuthService()
    {
        _premiosAuthRepository = RestService.For<IPremiosAuthRepository>(
            new HttpClient
            {
                BaseAddress = new Uri(PremiosVariables.AuthRoot)
            });
    }

    public async Task<TokenResponse?> GetAccessToken()
    {
        return await _premiosAuthRepository.GetTokenAsync(PremiosVariables.Key,
            PremiosVariables.AuthContentType,
            new GrantTypeObject(PremiosVariables.ClientCredentials, PremiosVariables.CampaignId));
    }
}