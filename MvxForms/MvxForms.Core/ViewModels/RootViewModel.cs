// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace MvxForms.Core.ViewModels
{
    public class RootViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public RootViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void ViewAppearing()
        {
            base.ViewAppearing();

            MvxNotifyTask.Create(async () =>
            {
                await _navigationService.Navigate<MasterViewModel>();
                await _navigationService.Navigate<MainViewModel>();
            });
        }
    }
}