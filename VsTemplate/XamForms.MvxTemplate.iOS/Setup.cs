using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.iOS;
using MvvmCross.iOS.Platform;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using UIKit;
using XamForms.MvxTemplate.Core;

namespace $safeprojectname$
{
    public class Setup : MvxFormsIosSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
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
