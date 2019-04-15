using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;

namespace Library.Core.ViewModels.Books
{
    public class BooksPageViewModel : BindableBase
    {
        public BooksPageViewModel()
        {
            AddBookCommand = new DelegateCommand(OnAddBookCmd);
        }

        private void OnAddBookCmd()
        {
            
        }

        public ICommand AddBookCommand { get; }
    }
}
