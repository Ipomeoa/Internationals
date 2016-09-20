﻿using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace CatchUp.Droid.Views
{
	[Activity(Label = "View for OptionsViewModel")]
	public class OptionsView : MvxActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Options);
		}
	}
}