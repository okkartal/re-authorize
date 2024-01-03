using shared;

namespace client;

public interface ICurrencyService
{
    Task<IEnumerable<Currency>?> GetCurrencyAsync();
}
