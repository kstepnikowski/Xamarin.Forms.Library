using System.Windows.Input;
using Library.Core.Views.Books;
using Prism.Commands;
using Prism.Navigation;

namespace Library.Core.ViewModels.Books
{
    public class BooksPageViewModel : ViewModelBase
    {

        private void OnAddBookCmd()
        {
            NavigationService.NavigateAsync(nameof(AddBookPage));
        }

        public ICommand AddBookCommand { get; }

        public BooksPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            AddBookCommand = new DelegateCommand(OnAddBookCmd);
        }
    }
}
