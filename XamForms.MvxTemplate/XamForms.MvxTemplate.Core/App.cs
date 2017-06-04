using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using Xamarin.Forms.Xaml;
using XamForms.MvxTemplate.Core.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamForms.MvxTemplate.Core
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
