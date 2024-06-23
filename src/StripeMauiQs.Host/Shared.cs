
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QuickStart.Dotnet.Stripe;

public static partial class ClientHelper
{
    public static async Task<(bool, string)> FetchPaymentIntent()
    {
        var request = new PaymentIntentCreateRequest
        {
            Items = [
                new Item
                {
                    Id = Guid.NewGuid().ToString(),
                    Amount = (new Random().NextDouble() * 100).ToString(),
                }
              ],
        };
        var httpClient = new HttpClient()
        {
            BaseAddress = new Uri(BACKEND_URL),
        };

        var response = await httpClient.PostAsJsonAsync("/create-payment-intent", request);

        if (!response.IsSuccessStatusCode)
        {
            return (false, $"API returned status code: {response.StatusCode.ToString()} {(int)response.StatusCode}");
        }

        var dataInJSON = await response.Content.ReadAsStringAsync();
        var data = JsonSerializer.Deserialize<PaymentIntentCreateResposne>(dataInJSON);

        return (true, data.ClientSecret);
    }
}

public record Item
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }
    [JsonPropertyName("Amount")]
    public required string Amount { get; set; }
}

public record PaymentIntentCreateRequest
{
    [JsonPropertyName("items")]
    public required Item[] Items { get; set; }
}

public record PaymentIntentCreateResposne
{
    [JsonPropertyName("clientSecret")]
    public required string ClientSecret { get; set; }
}

