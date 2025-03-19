using MAUI_IN_APP.Helpers;
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
		builder.Services.AddSingleton<IApkInstaller, ApkInstaller>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		Environment.SetEnvironmentVariable("IOS_STORE_SECRET", "MjA5ODBjZTktNmVhOS00ODExLWE4ZDctMmE4YTZhMGJlYjY4fDZmYmQwOTRjLTE4Y2ItNGJjZC1iYzZmLWNmMmFlZTc1Mjk4Mg==");
		Environment.SetEnvironmentVariable("ANDROID_STORE_SECRET", "NWY2YzYwY2QtM2ZhMS00YjJhLWIxNzItM2VlYzkyNDRhMDkxfDlhNjQ3Nzk0LTYyYzQtNGJlNS04MmQ3LTVmNDUwNWE3NWM2NQ==");
		Environment.SetEnvironmentVariable("STORE_URL", "https://store.store.appcircle.io");
		Environment.SetEnvironmentVariable("IOS_PROFILE_ID", "f2487ca0-188c-490f-9c28-ab0c41d15a3e");
		Environment.SetEnvironmentVariable("ANDROID_PROFILE_ID", "b3cdaf7b-6a1c-48e9-9f46-7671e641dba2");
		return builder.Build();
	}
}
