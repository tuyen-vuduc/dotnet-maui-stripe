namespace Stripe.PaymentSheets;

public record Configuration(string MerchantDisplayName)
{
    public ApplePaySettings? ApplePay { get; set; }

    public record ApplePaySettings(string MerchantId, string MerchantCountryCode) { }

    public record CustomerConfiguration(string Id, string EphemeralKeySecret) { }
}

public enum PaymentSheetResult
{
    Completed,
    Canceled,
}