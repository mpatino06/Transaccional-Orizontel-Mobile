package md5e3dfdb60d4ba0920745ec23c0477ae7d;


public class PrintActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("App.core.trans.Droid.PrintActivity, App.core.trans.Android", PrintActivity.class, __md_methods);
	}


	public PrintActivity ()
	{
		super ();
		if (getClass () == PrintActivity.class)
			mono.android.TypeManager.Activate ("App.core.trans.Droid.PrintActivity, App.core.trans.Android", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
