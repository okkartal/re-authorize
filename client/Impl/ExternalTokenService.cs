namespace client;

public class ExternalTokenService : IExternalTokenService
{
    public Task<Token> GetTokenAsync() => Task.FromResult(new Token()
    { AccessToken = Guid.NewGuid()
                        .ToString("N"), ExpiresIn = 3900, Scheme = "Bearer" });
}