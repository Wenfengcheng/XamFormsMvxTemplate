using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvxForms.Core.Repository;
using System.Collections.Generic;

namespace MvxForms.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly Services.IAppSettings _settings;
        private readonly IBookRepository _bookRepository;

        public MainViewModel(IMvxNavigationService navigationService, Services.IAppSettings settings, IBookRepository bookRepository)
        {
            _navigationService = navigationService;
            _settings = settings;

            _bookRepository = bookRepository;

            ButtonText = Resources.AppResources.MainPageButton;
        }

        public IMvxCommand PressMeCommand =>
            new MvxCommand(() =>
            {
                ButtonText = Resources.AppResources.MainPageButtonPressed;
            });

        public IMvxAsyncCommand GoToSecondPageCommand =>
            new MvxAsyncCommand(async () =>
            {
                var param = new Dictionary<string, string> { { "ButtonText", ButtonText } };

                await _navigationService.Navigate<SecondViewModel, Dictionary<string, string>>(param);
            });

        public IMvxCommand SqliteTestCommand =>
            new MvxCommand(() =>
            {
                _bookRepository.AddBook("book 1", "very good book");
                _bookRepository.AddBook("book 2", "very nice book");

                var books = _bookRepository.GetBooks();
            });

        public string ButtonText { get; set; }

        public int SuperNumber
        {
            get { return _settings.SuperNumber; }
            set { _settings.SuperNumber = value; }
        }
    }
}