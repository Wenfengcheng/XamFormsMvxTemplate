// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using MvvmCross.Forms.Droid;
using MvvmCross.Forms.Presenters;
using MvvmCross.Platform;
using Xamarin.Forms;

namespace MvxForms.Droid
{
    [Activity(Label = "FormsApplicationActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class FormsApplicationActivity : MvxFormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            ToolbarResource = Resource.Layout.Toolbar;
            TabLayoutResource = Resource.Layout.Tabbar;

            base.OnCreate(bundle);

            UserDialogs.Init(this);

            Mvx.Resolve<IMvxAppStart>().Start();
        }
    }
}