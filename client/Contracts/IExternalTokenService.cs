namespace client;

public interface IExternalTokenService
{
    Task<Token> GetTokenAsync();
}
