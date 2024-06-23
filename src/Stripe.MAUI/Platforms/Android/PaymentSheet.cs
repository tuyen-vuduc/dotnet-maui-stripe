using PS = Com.Stripe.Android.Paymentsheet;
using Microsoft.Maui.ApplicationModel;

namespace Stripe.PaymentSheets;

// All the code in this file is only included on Android.
partial class PaymentSheet : Java.Lang.Object
{
    private readonly PS.PaymentSheet paymentSheet;

    public PaymentSheet()
    {
        paymentSheet = new PS.PaymentSheet(Platform.CurrentActivity as AndroidX.Activity.ComponentActivity, this);
    }

    TaskCompletionSource<PaymentSheetResult> presentTaskCompletionSource;
    public Task<PaymentSheetResult> PresentWithPaymentIntentAsync(
        string paymentIntentClientSecret,
        Configuration configuration,
        CancellationToken cancellationToken = default)
    {
        if (presentTaskCompletionSource != null)
        {
            presentTaskCompletionSource?.TrySetCanceled(cancellationToken);
        }

        presentTaskCompletionSource = new TaskCompletionSource<PaymentSheetResult>();
        paymentSheet.PresentWithPaymentIntent(paymentIntentClientSecret, configuration.ToPlatform());

        return presentTaskCompletionSource.Task;
    }
}

partial class PaymentSheet : PS.IPaymentSheetResultCallback
{
    public void OnPaymentSheetResult(PS.PaymentSheetResult paymentSheetResult)
    {
        if (paymentSheetResult is PS.PaymentSheetResult.Completed)
        {
            presentTaskCompletionSource.TrySetResult(PaymentSheetResult.Completed);
        }
        else if (paymentSheetResult is PS.PaymentSheetResult.Canceled)
        {
            presentTaskCompletionSource.TrySetResult(PaymentSheetResult.Canceled);
        }
        else if (paymentSheetResult is PS.PaymentSheetResult.Failed failedResult)
        {
            presentTaskCompletionSource.TrySetException(failedResult.Error);
        }
    }
}

public static class PaymentSheetExtensions
{
    public static PS.PaymentSheet.Configuration ToPlatform(this Configuration configuration)
    {
        PS.PaymentSheet.Configuration xconfiguration = new PS.PaymentSheet.Configuration(
            configuration.MerchantDisplayName
        );

        return xconfiguration;
    }
}
