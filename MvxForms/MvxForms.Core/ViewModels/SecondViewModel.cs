using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvxForms.Core.ViewModels
{
    public class SecondViewModel : MvxViewModel<Dictionary<string, string>>
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly Services.IAppSettings _settings;

        private Dictionary<string, string> _parameter;

        public SecondViewModel(IMvxNavigationService navigationService, Services.IAppSettings settings)
        {
            _navigationService = navigationService;
            _settings = settings;

            MainPageButtonText = "test";
        }

        public string MainPageButtonText { get; set; }

        public IMvxAsyncCommand BackCommand => new MvxAsyncCommand(() => _navigationService.Close(this));

        public override Task Initialize(Dictionary<string, string> parameter)
        {
            _parameter = parameter;

            if (_parameter != null && _parameter.ContainsKey("ButtonText"))
                MainPageButtonText = "ButtonText";

            return Task.FromResult(true);
        }

        public int SuperNumber
        {
            get { return _settings.SuperNumber; }
            set { _settings.SuperNumber = value; }
        }
    }
}