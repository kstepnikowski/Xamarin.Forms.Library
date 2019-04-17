using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Core.Views.Books;
using Library.DataAccess.Entities;
using Library.DataAccess.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

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
        public ICommand RemoveBookCommand { get; }

        private readonly IPageDialogService _pageDialogService;
        private readonly IBooksService _booksService;

        public BooksPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IBooksService booksService) : base(navigationService)
        {
            _pageDialogService = pageDialogService;
            _booksService = booksService;
            AddBookCommand = new DelegateCommand<BookEntity>(OnAddBookCmd);
            RemoveBookCommand = new DelegateCommand<BookEntity>(OnRemoveBookCmd);
            GetBooks();
        }

        private void OnAddBookCmd(BookEntity book)
        {
            NavigationService.NavigateAsync(nameof(AddBookPage));
        }

        private async void OnRemoveBookCmd(BookEntity book)
        {
            var result = await _pageDialogService.DisplayAlertAsync("Usuń książkę",
                $"Czy chcesz usunąć książkę {book.Title}?", "Tak", "Nie");

            if(!result)
                return;

            _booksService.RemoveBook(book.Id);
            GetBooks();
        }

        private void GetBooks()
        {
            Books = _booksService.GetAll();
            IsInfoVisible = Books.Count == 0;
        }
    }
}
