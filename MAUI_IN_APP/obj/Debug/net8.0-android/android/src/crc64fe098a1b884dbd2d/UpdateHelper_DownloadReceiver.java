package crc64fe098a1b884dbd2d;


public class UpdateHelper_DownloadReceiver
	extends android.content.BroadcastReceiver
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onReceive:(Landroid/content/Context;Landroid/content/Intent;)V:GetOnReceive_Landroid_content_Context_Landroid_content_Intent_Handler\n" +
			"";
		mono.android.Runtime.register ("MAUI_IN_APP.Helpers.UpdateHelper+DownloadReceiver, MAUI_IN_APP", UpdateHelper_DownloadReceiver.class, __md_methods);
	}


	public UpdateHelper_DownloadReceiver ()
	{
		super ();
		if (getClass () == UpdateHelper_DownloadReceiver.class) {
			mono.android.TypeManager.Activate ("MAUI_IN_APP.Helpers.UpdateHelper+DownloadReceiver, MAUI_IN_APP", "", this, new java.lang.Object[] {  });
		}
	}

	public UpdateHelper_DownloadReceiver (android.content.Context p0, long p1)
	{
		super ();
		if (getClass () == UpdateHelper_DownloadReceiver.class) {
			mono.android.TypeManager.Activate ("MAUI_IN_APP.Helpers.UpdateHelper+DownloadReceiver, MAUI_IN_APP", "Android.Content.Context, Mono.Android:System.Int64, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public void onReceive (android.content.Context p0, android.content.Intent p1)
	{
		n_onReceive (p0, p1);
	}

	private native void n_onReceive (android.content.Context p0, android.content.Intent p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
