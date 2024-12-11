using LinkBucket.Model;
using LinkBucket.Model.GetToken;
using Refit;

namespace LinkBucket.Refit.Premios.Auth;

public interface IPremiosAuthRepository
{
    [Post("/connect/token")]
    public Task<TokenResponse?> GetTokenAsync(
        [Header("Authorization")] string authorization,
        [Header("Content-Type")] string contentType,
        [Body(BodySerializationMethod.UrlEncoded)]
        GrantTypeObject content);
}