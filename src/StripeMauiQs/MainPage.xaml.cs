using Stripe.PaymentSheets;

namespace StripeMauiQs;

public partial class MainPage : ContentPage
{
	public MainPage(IPaymentSheet paymentSheet)
	{
		InitializeComponent();
	}

	private void OnPayNow(object sender, EventArgs e)
	{
		
	}
}


