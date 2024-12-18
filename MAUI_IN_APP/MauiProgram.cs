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
		Environment.SetEnvironmentVariable("ANDROID_STORE_SECRET", "NWViMWFkZjktMGE4My00OGMxLTk2NDMtZjVlMjMzZmMyNzVlfDZmYmQwOTRjLTE4Y2ItNGJjZC1iYzZmLWNmMmFlZTc1Mjk4Mg==");
		Environment.SetEnvironmentVariable("STORE_URL", "https://sarp.store.appcircle.io");
		Environment.SetEnvironmentVariable("IOS_PROFILE_ID", "f2487ca0-188c-490f-9c28-ab0c41d15a3e");
		Environment.SetEnvironmentVariable("ANDROID_PROFILE_ID", "8f5acd24-dd25-4464-b49c-655630db9f2b");
		return builder.Build();
	}
}
