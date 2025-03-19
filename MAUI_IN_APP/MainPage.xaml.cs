using MAUI_IN_APP.Helpers;

namespace MAUI_IN_APP;

public partial class MainPage : ContentPage
{
	int count = 0;
	public MainPage()
	{
		InitializeComponent();
		string version = AppInfo.VersionString;
		string build = AppInfo.BuildString;

		WelcomeLabel.Text = $"Version: {version} (Build: {build})";
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();

		await UpdateControl();
	}
	private async void OnCounterClicked(object sender, EventArgs e)
	{
		try
		{

		}
		catch(Exception ex)
		{
			//ignore
		}

	}

	public async Task UpdateControl()
	{
		var currentVersion = AppInfo.VersionString;
		var updateInfo = await InAppUpdateHelper.CheckForUpdate(currentVersion, "USER_EMAIL");
		
		if (updateInfo?.DownloadUrl != null && await Launcher.CanOpenAsync(updateInfo.DownloadUrl))
		{
			bool result = await DisplayAlert("Update Available",$"{updateInfo.Version} version is available.", "Update","Cancel");
			if (result)
			{
				var context = Android.App.Application.Context;
				var updateHelper = new UpdateHelper(context);
				updateHelper.StartDownload(updateInfo.DownloadUrl);
			}
		}
	}
}

