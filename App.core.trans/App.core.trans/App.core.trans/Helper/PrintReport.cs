using System;
using System.Collections.Generic;
using System.Text;
using Android.Content;

namespace App.core.trans.Helper
{
    public class PrintReport
    {

		public void Print(string text)
		{
			try
			{
				Intent intentPrint = new Intent();

				intentPrint.SetAction(Intent.ActionSend);
				intentPrint.PutExtra(Intent.ExtraText, text);
				intentPrint.SetType("text/plain");
				Android.App.Application.Context.StartActivity(intentPrint);
			}
			catch (Exception ex)
			{

			}

		}

    }
}
