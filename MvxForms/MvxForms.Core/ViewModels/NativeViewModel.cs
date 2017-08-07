// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using Acr.UserDialogs;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvxForms.Core.Services;

namespace MvxForms.Core.ViewModels
{
    public class NativeViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly Services.IAppSettings _settings;
        private readonly IUserDialogs _userDialogs;
        private readonly ILocalizeService _localizeService;

        public NativeViewModel(IMvxNavigationService navigationService, Services.IAppSettings settings, IUserDialogs userDialogs, ILocalizeService localizeService)
        {
            _navigationService = navigationService;
            _settings = settings;
            _userDialogs = userDialogs;
            _localizeService = localizeService;
        }

        public IMvxAsyncCommand BackCommand => new MvxAsyncCommand(async () =>
        {
            await _navigationService.Close(this);
        });
    }
}