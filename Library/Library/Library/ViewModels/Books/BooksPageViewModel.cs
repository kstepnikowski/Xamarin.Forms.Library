using System.Collections.Generic;
using System.Windows.Input;
using Library.Core.Views.Books;
using Library.DataAccess.Entities;
using Library.DataAccess.Repositories.BookRepository;
using Prism.Commands;
using Prism.Navigation;

namespace Library.Core.ViewModels.Books
{
    public class BooksPageViewModel : ViewModelBase
    {
        private List<BookEntity> _books;
        public List<BookEntity> Books
        {
            get => _books;
            set => SetProperty(ref _books, value);
        }

        private bool _isInfoVisible;
        public bool IsInfoVisible
        {
            get => _isInfoVisible;
            set => SetProperty(ref _isInfoVisible, value);
        }

        public ICommand AddBookCommand { get; }

        private readonly IBooksRepository _booksRepository;

        public BooksPageViewModel(INavigationService navigationService, IBooksRepository booksRepository) : base(navigationService)
        {
            _booksRepository = booksRepository;
            AddBookCommand = new DelegateCommand(OnAddBookCmd);
        }

        public async void GetBooks()
        {
            var books = await _booksRepository.GetAll();
            Books = books ?? new List<BookEntity>();
            IsInfoVisible = Books.Count==0;
        }

        private void OnAddBookCmd()
        {
            NavigationService.NavigateAsync(nameof(AddBookPage));
        }
    }
}
