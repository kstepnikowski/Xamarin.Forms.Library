using System.Windows.Input;
using Library.Core.Views;
using Prism.Commands;
using Prism.Navigation;

namespace Library.Core.ViewModels.Books
{
    public class AddBookPageViewModel : ViewModelBase
    {
        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                SetProperty(ref _title, value);
                CanExecute();
            }
        }

        private string _author;
        public string Author
        {
            get => _title;
            set
            {
                SetProperty(ref _title, value);
                CanExecute();
            }
        }

        private bool _isEnabledAddButton;
        public bool IsEnabledAddButton
        {
            get => _isEnabledAddButton;
            set => SetProperty(ref _isEnabledAddButton, value);
        }

   
        public ICommand AddBookCommand { get; }

        public AddBookPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            AddBookCommand = new DelegateCommand(AddBookCmd);
        }

        private void CanExecute()
        {
            IsEnabledAddButton = !string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(Author);
        }

        private void AddBookCmd()
        {
            NavigationService.NavigateAsync(nameof(HomePage));
        }
    }
}
