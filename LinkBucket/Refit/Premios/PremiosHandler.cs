using LinkBucket.Refit.Premios.Auth;
using LinkBucket.SecretVariables;

namespace LinkBucket.Refit.Premios;

public class PremiosHandler : DelegatingHandler
{
    private readonly PremiosAuthService _premiosAuthService = new();

    public PremiosHandler() : base(new HttpClientHandler())
    {
    }

    private static string Authorization => "Authorization";
    private static string SubscriptionKey => "Ocp-Apim-Subscription-Key";
    private static string CatalogId => "catalogId";
    private static string ParticipantId => "participantId";
    private static string CampaignId => "campaignId";
    private static string Username => "username";
    private static string ProfileId => "profileId";

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var token = await _premiosAuthService.GetAccessToken();

        if (token is null)
            throw new UnauthorizedAccessException();

        AddRequiredHeaders(request, token.AccessToken);

        return await base.SendAsync(request, cancellationToken);
    }

    private void AddRequiredHeaders(HttpRequestMessage request, string token)
    {
        request.Headers.Add(Authorization, token);
        request.Headers.Add(SubscriptionKey, PremiosVariables.SubscriptionKey);
        request.Headers.Add(CatalogId, PremiosVariables.CatalogId);
        request.Headers.Add(ParticipantId, PremiosVariables.ParticipantId);
        request.Headers.Add(CampaignId, PremiosVariables.CampaignId);
        request.Headers.Add(Username, PremiosVariables.Username);
        request.Headers.Add(ProfileId, PremiosVariables.ProfileId);
    }
}