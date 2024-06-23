using Foundation;
using TVStripePaymentSheet;

namespace Stripe.PaymentSheets;

// All the code in this file is only included on Android.
public partial class PaymentSheet
{
    public Task<PaymentSheetResult> PresentWithPaymentIntentAsync(
        string paymentIntentClientSecret,
        Configuration configuration,
        CancellationToken cancellationToken = default)
    {
        var paymentSheet = new TSPSPaymentSheet(
            paymentIntentClientSecret: paymentIntentClientSecret,
            configuration: configuration.ToPlatform());

        var tcs = new TaskCompletionSource<PaymentSheetResult>();
        paymentSheet.PresentFrom(
            Platform.GetCurrentUIViewController(),
            (paymentResult, error) => {
            switch (paymentResult)
            {
                case TSPSPaymentSheetResult.Completed:
                    tcs.TrySetResult(PaymentSheetResult.Completed);
                    break;
                case TSPSPaymentSheetResult.Canceled:
                    tcs.TrySetResult(PaymentSheetResult.Canceled);
                    break;
                default:
                    tcs.TrySetException(new NSErrorException(
                        error ?? new NSError(new NSString("Unknown"), nint.MaxValue)
                    ));
                    break;
            }
        });

        return tcs.Task;
    }
}

public static class PaymentSheetExtensions
{
    public static TSPSConfiguration ToPlatform(this Configuration configuration)
    {
        var xconfiguration = new TSPSConfiguration();
        configuration.MerchantDisplayName = configuration.MerchantDisplayName;

        return xconfiguration;
    }
}