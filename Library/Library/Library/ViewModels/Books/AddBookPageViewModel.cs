using System.Windows.Input;
using Library.Core.Views;
using Library.DataAccess.Entities;
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

        //private readonly IBooksRepository _booksRepository;

        public AddBookPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            //_booksRepository = booksRepository;
            AddBookCommand = new DelegateCommand(AddBookCmd);
        }

        private void CanExecute()
        {
            IsEnabledAddButton = !string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(Author);
        }

        private void AddBookCmd()
        {
            var book = new BookEntity(Title, Author);
            //_booksRepository.Add(book);
            NavigationService.NavigateAsync(nameof(HomePage));
        }
    }
}
