using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Forms.Core;
using MvvmCross.Forms.Droid;
using MvvmCross.Forms.Droid.Presenters;
using MvvmCross.Platform;
using Xamarin.Forms;

namespace XamForms.MvxTemplate.Droid
{
    [Activity(Label = "FormsApplicationActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class FormsApplicationActivity : MvxFormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);

            var app = new MvxFormsApplication();
            var presenter = Mvx.Resolve<IMvxViewPresenter>() as MvxFormsDroidPagePresenter;
            presenter.MvxFormsApp = app;

            LoadApplication(app);

            Mvx.Resolve<IMvxAppStart>().Start();
        }
    }
}