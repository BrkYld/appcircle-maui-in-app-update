package crc64fe098a1b884dbd2d;


public class DownloadReceiver
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
		mono.android.Runtime.register ("MAUI_IN_APP.Helpers.DownloadReceiver, MAUI_IN_APP", DownloadReceiver.class, __md_methods);
	}


	public DownloadReceiver ()
	{
		super ();
		if (getClass () == DownloadReceiver.class) {
			mono.android.TypeManager.Activate ("MAUI_IN_APP.Helpers.DownloadReceiver, MAUI_IN_APP", "", this, new java.lang.Object[] {  });
		}
	}

	public DownloadReceiver (java.lang.String p0)
	{
		super ();
		if (getClass () == DownloadReceiver.class) {
			mono.android.TypeManager.Activate ("MAUI_IN_APP.Helpers.DownloadReceiver, MAUI_IN_APP", "System.String, System.Private.CoreLib", this, new java.lang.Object[] { p0 });
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
