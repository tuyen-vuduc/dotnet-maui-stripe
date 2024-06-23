# Stripe for .NET MAUI

[Stripe](https://www.stripe.com/) is a well-known payment gateway providing a wide range of payment products and solutions.

## Prerequisites

- .NET 8
- Visual Studio or Visual Studio Code
- .NET workloads for .NET MAUI

## Steps to run the sample app

1/ Open `dotnet-maui-stripe.sln` file

2/ Create `Shared.dev.cs` as a copy of `Shared.dev.cs.sample`

```
|- src
    |- StripeMauiQs.Host
        |- Shared.cs
        |- Shared.dev.cs

```

3/ Replace the placeholder with your key

4/ Run `StripeMauiQs.Host` without debugging

5/ Use [ngrok](https://ngrok.com) to expose your local server for accessing from mobile device(s)/simulator(s)/emulator(s)

```
ngrok http http://localhost:4242
```

6/ Set value of `BACKEND_URL` in `Shared.dev.cs` to the generated ngrok URL

7/ Run and check out the app

## Steps to use in your app

1/ Install the nuget package
```
<PackageReference Include="Stripe.MAUI" Version="1.204600.232705" />
```

2/ Call `UseStripe` in your `MauiProgram.cs`

3/ Inject `IPaymentSheet` into your class

4/ Try to invoke relevant method e.g. `PresentWithPaymentIntentAsync`

## MAINTAINER

This project is maintained by [tuyen-vuduc](https://github.com/tuyen-vuduc) in his spare time.<br>

If you find this project is useful, please become a sponsor of the project and/or buy him a coffee.

[!["Buy Me A Coffee"](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/tuyen.vuduc)

OR

[![](https://img.shields.io/static/v1?label=Sponsor&message=%E2%9D%A4&logo=GitHub&color=%23fe8e86)](https://github.com/sponsors/tuyen-vuduc)

## LICENSE

The 3rd libraries will follow their associated licenses. This project itself is licensed under The 3-Clause BSD License.

Copyright 2024 tuyen-vuduc

Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.

3. Neither the name of the copyright holder nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS “AS IS” AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
