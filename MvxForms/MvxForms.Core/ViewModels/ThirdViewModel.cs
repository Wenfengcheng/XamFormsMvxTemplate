// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvxForms.Core.Helpers;
using MvxForms.Core.Services;

namespace MvxForms.Core.ViewModels
{
    public class ThirdViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService navigationService;
        private readonly Services.IAppSettings settings;
        private readonly IUserDialogs userDialogs;
        private readonly ILocalizeService localizeService;


        public ThirdViewModel(IMvxNavigationService navigationService, Services.IAppSettings settings, IUserDialogs userDialogs, ILocalizeService localizeService)
        {
            this.navigationService = navigationService;
            this.settings = settings;
            this.userDialogs = userDialogs;
            this.localizeService = localizeService;
        }

        public IMvxAsyncCommand BackCommand => new MvxAsyncCommand(async () =>
        {
            var localizedText = localizeService.Translate("ThirdPage_ByeBye_Localization");

            await userDialogs.AlertAsync(localizedText);
            await navigationService.Close(this);
        });

        public int SuperNumber
        {
            get { return settings.SuperNumber; }
            set { settings.SuperNumber = value; }
        }
    }
}