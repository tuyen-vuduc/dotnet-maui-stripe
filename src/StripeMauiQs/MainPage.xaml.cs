using System.Diagnostics;
using Microsoft.Maui.ApplicationModel;
using Stripe.PaymentSheets;

namespace StripeMauiQs;

public partial class MainPage : ContentPage
{
    private string paymentIntentClientSecret;

    public MainPage()
	{
		InitializeComponent();
    }

    private async void OnFetchPaymentIntent(object sender, EventArgs e)
    {
        await QuickStart.Dotnet.Stripe.ClientHelper.FetchPaymentIntent()
            .ContinueWith(t =>
            {
                var (ok, msg) = t.Result;
                if (!ok)
                {
                    MainThread.BeginInvokeOnMainThread(() => DisplayAlert("API Error", msg, "OK"));
                    return;
                }

                paymentIntentClientSecret = msg;

                MainThread.BeginInvokeOnMainThread(() => PayNowButton.IsEnabled = true);
            })
            .ConfigureAwait(false);
    }

    private async void OnPayNow(object sender, EventArgs e)
	{
        var configuration = new Configuration("TuyenTV.dev Co.Ltd.");

        var paymentSheet = Handler.MauiContext.Services.GetService<IPaymentSheet>();
        var (result, msg) = await paymentSheet.PresentWithPaymentIntentAsync(paymentIntentClientSecret, configuration)
            .ContinueWith(t =>
            {
                if (t.IsCompletedSuccessfully) return (t.Result, null);

                return (PaymentSheetResult.Canceled, "Cannot pay for a reason...");
            });

        switch(result)
        {
            case PaymentSheetResult.Completed:
                await DisplayAlert("Payment Result", "Payment completed successfully!", "OK");
                break;
            case PaymentSheetResult.Canceled:
                if (!string.IsNullOrWhiteSpace(msg))
                {
                    await DisplayAlert("Payment Result", "Payment completed failed!", "Try again");
                }
                break;
        }

        Debug.WriteLine("Payment complete.");
	}
}


