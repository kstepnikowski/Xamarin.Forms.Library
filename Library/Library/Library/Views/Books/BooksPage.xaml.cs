using Library.Core.ViewModels.Books;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Library.Core.Views.Books
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BooksPage : ContentPage
	{
		public BooksPage ()
		{
			InitializeComponent ();
		}

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
            (BindingContext as BooksPageViewModel)?.GetBooks();
	    }
	}
}