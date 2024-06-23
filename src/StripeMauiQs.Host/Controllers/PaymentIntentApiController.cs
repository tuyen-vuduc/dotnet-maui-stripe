using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace StripeMauiQs.Host.Controllers
{
    [ApiController]
    [Route("create-payment-intent")]
    public class PaymentIntentApiController : ControllerBase
    {
        [HttpPost]
        public object Create([FromBody] QuickStart.Dotnet.Stripe.PaymentIntentCreateRequest request)
        {
            var paymentIntentService = new PaymentIntentService();
            var paymentIntent = paymentIntentService.Create(new PaymentIntentCreateOptions
            {
                Amount = CalculateOrderAmount(request.Items),
                Currency = "usd",
                // In the latest version of the API, specifying the `automatic_payment_methods` parameter is optional because Stripe enables its functionality by default.
                AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                {
                    Enabled = true,
                },
            });

            return new QuickStart.Dotnet.Stripe.PaymentIntentCreateResposne { ClientSecret = paymentIntent.ClientSecret };
        }

        private int CalculateOrderAmount(QuickStart.Dotnet.Stripe.Item[] items)
        {
            // Replace this constant with a calculation of the order's amount
            // Calculate the order total on the server to prevent
            // people from directly manipulating the amount on the client
            return 1400;
        }
    }
}
