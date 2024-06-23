namespace Stripe.PaymentSheets;

public partial class PaymentSheet : IPaymentSheet
{
}

public partial interface IPaymentSheet
{
    Task<PaymentSheetResult> PresentWithPaymentIntentAsync(
        string paymentIntentClientSecret,
        Configuration configuration,
        CancellationToken cancellationToken = default);
}