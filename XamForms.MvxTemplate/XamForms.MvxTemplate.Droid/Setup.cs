using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.Droid;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using XamForms.MvxTemplate.Core;

namespace XamForms.MvxTemplate.Droid
{
    public class Setup : MvxFormsAndroidSetup
    {
        public Setup(Context applicationContext)
            : base(applicationContext)
        {
        }

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.RegisterSingleton<Core.Services.ILocalizeService>(new Services.LocalizeService());
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}