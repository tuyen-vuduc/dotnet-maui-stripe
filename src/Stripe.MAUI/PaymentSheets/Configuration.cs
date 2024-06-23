namespace Stripe.PaymentSheets;

public record Configuration {
    public required string MerchantDisplayName { get;set; }
    public ApplePaySettings? ApplePay { get;set; }

    public record ApplePaySettings(string MerchantId, string MerchantCountryCode) {}

    public record CustomerConfiguration(string Id, string EphemeralKeySecret) {}
}

public enum PaymentSheetResult
{
    Completed,
    Canceled,
}