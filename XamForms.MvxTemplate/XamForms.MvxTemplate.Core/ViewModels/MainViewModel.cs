using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using XamForms.MvxTemplate.Core.Resources;

namespace XamForms.MvxTemplate.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public MainViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public IMvxCommand PressMeCommand => new MvxCommand(PressMe);

        public IMvxAsyncCommand GoToSecondPageCommand
        {
            get
            {
                return new MvxAsyncCommand(async () =>
                {
                    var param = new Dictionary<string, string> { { "ButtonText", ButtonText } };

                    await _navigationService.Navigate<SecondViewModel, Dictionary<string, string>>(param);
                });
            }
        }

        private string _buttonText = AppResources.MainPageButton;
        public string ButtonText
        {
            get
            {
                return _buttonText;
            }
            set
            {
                SetProperty(ref _buttonText, value);
            }
        }

        public void PressMe()
        {
            ButtonText = AppResources.MainPageButtonPressed;
        }
    }
}
