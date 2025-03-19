using Android.App;
using Android.Content;
using Android.Database;
using Android.Net;
using Android.OS;
using Android.Provider;
using Android.Webkit;
using System;
using System.IO;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Application = Microsoft.Maui.Controls.Application;
using Environment = Android.OS.Environment;
using Exception = Java.Lang.Exception;
using Uri = Android.Net.Uri;

namespace MAUI_IN_APP.Helpers;

public class UpdateHelper
{
    private readonly Context _context;
    private long _downloadId;
    private string _apkFilePath;

    public UpdateHelper(Context context)
    {
        _context = context;
    }

    public void StartDownload(string apkUrl)
    {
        var downloadManager = (DownloadManager)_context.GetSystemService(Context.DownloadService);
        Uri uri = Uri.Parse(apkUrl);

        var request = new DownloadManager.Request(uri);
        request.SetTitle("Downloading Update...");
        request.SetDescription("Please wait while the update is downloading.");
        request.SetDestinationInExternalPublicDir(Environment.DirectoryDownloads, "ac.apk");
        request.SetNotificationVisibility(DownloadVisibility.VisibleNotifyCompleted);
        request.SetAllowedNetworkTypes(DownloadNetwork.Wifi | DownloadNetwork.Mobile);

        _downloadId = downloadManager.Enqueue(request);

        // Register broadcast receiver
        var receiver = new DownloadReceiver(_context, _downloadId);
        _context.RegisterReceiver(receiver, new IntentFilter(DownloadManager.ActionDownloadComplete));
    }
    [BroadcastReceiver(Enabled = true, Exported = false)]
    public class DownloadReceiver : BroadcastReceiver
    {
        private readonly Context _context;
        private readonly long _downloadId;

        public DownloadReceiver() { }

        public DownloadReceiver(Context context, long downloadId)
        {
            _context = context;
            _downloadId = downloadId;
        }

        public override void OnReceive(Context context, Intent intent)
        {
            long id = intent.GetLongExtra(DownloadManager.ExtraDownloadId, -1);
            if (id == _downloadId)
            {
                InstallUpdate(context);
            }
        }

        private void InstallUpdate(Context context)
        {
            var downloadManager = (DownloadManager)context.GetSystemService(Context.DownloadService);
            var query = new DownloadManager.Query();
            query.SetFilterById(_downloadId);
            var cursor = downloadManager.InvokeQuery(query);

            if (cursor.MoveToFirst())
            {
                try
                {
                    int columnIndex = cursor.GetColumnIndex(DownloadManager.ColumnLocalUri);
                    string fileUri = cursor.GetString(columnIndex);
                    cursor.Close();
                    var file = new Java.IO.File(fileUri.Replace("file://", ""));
                    Uri apkUri = null;
                    /*if (Build.VERSION.SdkInt >= BuildVersionCodes.N)
                    {
                        apkUri = FileProvider.GetUriForFile(context,
                            "com.appcircle.sample_flutter_google_submit_app.fileprovider", file);
                        context.GrantUriPermission(context.PackageName, apkUri, ActivityFlags.GrantReadUriPermission);
                    }
                    else
                    {
                        apkUri = Uri.Parse(fileUri);
                    }*/

                    var packageManager = Microsoft.Maui.ApplicationModel.Platform.CurrentActivity.PackageManager;
                    var res = packageManager.CanRequestPackageInstalls();
                    if (!res)
                    {
                        Microsoft.Maui.ApplicationModel.Platform.CurrentActivity.StartActivity(new Android.Content.Intent(Android.Provider.Settings.ActionManageUnknownAppSources, Android.Net.Uri.Parse("package:" + AppInfo.Current.PackageName)));
                    }
                    else
                    {
                        var _context = Platform.AppContext;
                        Java.IO.File apkFile = file;
                        var res1=apkFile.Exists();
                        Android.Content.Intent intent = new Android.Content.Intent(Android.Content.Intent.ActionView);
                        
                        var uri = Microsoft.Maui.Storage.FileProvider.GetUriForFile(context, context.ApplicationContext.PackageName + ".fileProvider", apkFile);
                        intent.SetDataAndType(uri, "application/vnd.android.package-archive");
                        intent.AddFlags(Android.Content.ActivityFlags.NewTask);
                        intent.AddFlags(Android.Content.ActivityFlags.GrantReadUriPermission);
                        intent.AddFlags(Android.Content.ActivityFlags.ClearTop);
                        
                        intent.PutExtra(Android.Content.Intent.ExtraNotUnknownSource, true);
                        intent.PutExtra("apkPath", fileUri);
                        Platform.CurrentActivity.StartActivityForResult(intent, 1);
                    }
                    /*Intent installIntent = new Intent(Intent.ActionView);
                    installIntent.SetDataAndType(apkUri, "application/vnd.android.package-archive");
                    installIntent.SetFlags(ActivityFlags.NewTask | ActivityFlags.GrantReadUriPermission);
                    context.StartActivity(installIntent);*/
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}