using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MvxForms.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            CreatableTypes().
                EndingWith("Repository")
                .AsTypes()
                .RegisterAsLazySingleton();

            Mvx.RegisterType<Services.IAppSettings, Services.AppSettings>();

            Resources.AppResources.Culture = Mvx.Resolve<Services.ILocalizeService>().GetCurrentCultureInfo();

            RegisterAppStart<ViewModels.MainViewModel>();
        }
    }
}
