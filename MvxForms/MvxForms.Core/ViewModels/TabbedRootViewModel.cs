// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace MvxForms.Core.ViewModels
{
    public class TabbedRootViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService mvxNavigationService;

        public TabbedRootViewModel(IMvxNavigationService mvxNavigationService)
        {
            this.mvxNavigationService = mvxNavigationService;
        }

        public override void ViewAppearing()
        {
            base.ViewAppearing();

            MvxNotifyTask.Create(async () =>
            {
                await mvxNavigationService.Navigate<MainViewModel>();
                await mvxNavigationService.Navigate<SecondViewModel>();
            });
        }
    }
}