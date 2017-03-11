using System.Windows.Input;
using Xamarin.Forms;
using XamForms.MvxTemplate.Core.Resources;

namespace XamForms.MvxTemplate.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _buttonText = AppResources.MainPageButton;

        public MainViewModel()
        {
            this.PressMeCommand = new Command(() => this.PressMe());
        }

        public ICommand PressMeCommand
        {
            get; protected set;
        }

        public string ButtonText
        {
            get
            {
                return _buttonText;
            }
            set
            {
                _buttonText = value;
                RaisePropertyChanged(() => ButtonText);
            }
        }

        public void PressMe()
        {
            ButtonText = AppResources.MainPageButtonPressed;
        }
    }
}
