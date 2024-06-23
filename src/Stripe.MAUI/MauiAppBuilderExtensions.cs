using Microsoft.Maui.LifecycleEvents;
using Stripe.PaymentSheets;

#if __ANDROID__
using Com.Stripe.Android;
#elif __IOS__
using StripeCore;
#endif

namespace Stripe;

// All the code in this file is included in all platforms.
public static class MauiAppBuilderExtensions
{
    public static MauiAppBuilder UseStripe(
        this MauiAppBuilder builder,
        string? defaultPublishableKey)
    {
#if __ANDROID__
        if (!string.IsNullOrWhiteSpace(defaultPublishableKey))
        {
            builder.ConfigureLifecycleEvents(lifeCycle =>
            {
                lifeCycle.AddAndroid(alc =>
                {
                    alc.OnApplicationCreate((app) =>
                    {
                        PaymentConfiguration.Init(
                            app.ApplicationContext,
                            defaultPublishableKey
                        );
                    });
                });
            });
        }
#elif __IOS__

        if (!string.IsNullOrWhiteSpace(defaultPublishableKey))
        {
            StripeAPI.DefaultPublishableKey = defaultPublishableKey;
        }
#endif

        builder.Services.AddSingleton<IPaymentSheet, PaymentSheet>();

        return builder;
    }
}

