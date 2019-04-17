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
		    BooksListView.ItemSelected += (e, sender) => BooksListView.SelectedItem = null;
		}
	}
}