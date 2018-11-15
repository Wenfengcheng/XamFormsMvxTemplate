// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using MvvmCross;
using MvvmCross.Forms.Platforms.Uap.Views;
using MvvmCross.Logging;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;

namespace MvxForms.UWP
{
    sealed partial class App
    {
        public App()
        {
            InitializeComponent();
        }
    }

    public abstract class UwpApp : MvxWindowsApplication<Setup, Core.MvxApp, Core.FormsApp, MainPage>
    {
        public UwpApp()
        {
            this.UnhandledException += App_UnhandledException;
            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;
        }

        private void App_UnhandledException(object sender, Windows.UI.Xaml.UnhandledExceptionEventArgs args)
        {
            var mvxLogProvider = Mvx.IoCProvider.Resolve<IMvxLogProvider>();
            var mvxLog = mvxLogProvider.GetLogFor(GetType());
            mvxLog.TraceException(args.Exception.Message, args.Exception);
        }

        private void TaskSchedulerOnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs args)
        {
            var mvxLogProvider = Mvx.IoCProvider.Resolve<IMvxLogProvider>();
            var mvxLog = mvxLogProvider.GetLogFor(GetType());
            mvxLog.TraceException(args.Exception.Message, args.Exception);
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {

#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            base.OnLaunched(e);
        }
    }
}