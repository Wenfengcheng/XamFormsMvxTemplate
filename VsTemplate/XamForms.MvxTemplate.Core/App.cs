using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using Xamarin.Forms.Xaml;
using $safeprojectname$.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace $safeprojectname$
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

            Resources.AppResources.Culture = Mvx.Resolve<Services.ILocalizeService>().GetCurrentCultureInfo();

            RegisterAppStart<MainViewModel>();
        }
    }
}
