using System.Net.Http.Json;
using shared;

namespace client;

public class CurrencyService : ICurrencyService
{
    private readonly HttpClient _httpClient;

    public CurrencyService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Currency>?> GetCurrencyAsync()
    {
        var response = await _httpClient.GetAsync("/currency");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<Currency>>();
    }
}

