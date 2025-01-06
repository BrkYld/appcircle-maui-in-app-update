using Microsoft.Extensions.Logging;

namespace MAUI_IN_APP;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		Environment.SetEnvironmentVariable("IOS_STORE_SECRET", "MjA5ODBjZTktNmVhOS00ODExLWE4ZDctMmE4YTZhMGJlYjY4fDZmYmQwOTRjLTE4Y2ItNGJjZC1iYzZmLWNmMmFlZTc1Mjk4Mg==");
		Environment.SetEnvironmentVariable("ANDROID_STORE_SECRET", "ZGYyYzU3MzktODg5MC00ZTE2LWJjNGEtMWI4NTkyZGJkMDVkfDZmYmQwOTRjLTE4Y2ItNGJjZC1iYzZmLWNmMmFlZTc1Mjk4Mg==");
		Environment.SetEnvironmentVariable("STORE_URL", "https://store.store.appcircle.io");
		Environment.SetEnvironmentVariable("IOS_PROFILE_ID", "f2487ca0-188c-490f-9c28-ab0c41d15a3e");
		Environment.SetEnvironmentVariable("ANDROID_PROFILE_ID", "ef02714e-7855-4dfa-afaa-c36affa189bd");
		return builder.Build();
	}
}
