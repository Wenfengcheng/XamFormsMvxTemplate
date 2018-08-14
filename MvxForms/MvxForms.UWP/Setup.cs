// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using MvvmCross;
using MvvmCross.Forms.Platforms.Uap.Core;
using MvvmCross.Logging;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Serilog;
using System.IO;
using Windows.Storage;

namespace MvxForms.UWP
{
    public class Setup : MvxFormsWindowsSetup<Core.MvxApp, Core.FormsApp>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.RegisterSingleton<Core.Services.ILocalizeService>(() => new Services.LocalizeService());
            Mvx.RegisterSingleton<ISettings>(() => CrossSettings.Current);
        }

        public override MvxLogProviderType GetDefaultLogProviderType() => MvxLogProviderType.Serilog;

        protected override IMvxLogProvider CreateLogProvider()
        {
            var logPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Logs", "log-{Date}.txt");

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Trace()
                .WriteTo.RollingFile(logPath)
                .CreateLogger();

            return base.CreateLogProvider();
        }
    }
}