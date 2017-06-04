using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.Uwp;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using Windows.ApplicationModel.Activation;
using XamForms.MvxTemplate.Core;
using XamlControls = Windows.UI.Xaml.Controls;

namespace XamForms.MvxTemplate.UWP
{
    public class Setup : MvxFormsWindowsSetup
    {
        private readonly LaunchActivatedEventArgs _launchActivatedEventArgs;

        public Setup(XamlControls.Frame rootFrame, LaunchActivatedEventArgs e) : base(rootFrame, e)
        {
            _launchActivatedEventArgs = e;
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