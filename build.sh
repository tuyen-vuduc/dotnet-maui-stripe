dotnet nuget locals -c all

# Build to trigger gradle process
dotnet build -t:Clean,Rebuild src/StripeMauiQs/StripeMauiQs.csproj

dotnet pack -c Release -t:Clean,Rebuild src/Stripe.MAUI/Stripe.MAUI.csproj --output $PWD/nugets -p:AndroidSdkDirectory=$ANDROID_HOME