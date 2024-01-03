using Microsoft.Extensions.Http.Resilience;
using Polly;

namespace client;

public interface ICachedTokenService
{
    ValueTask<Token> GetTokenAsync(ResilienceContext context);
    Task<Token> RefreshTokenAsync(ResilienceContext context);
}
