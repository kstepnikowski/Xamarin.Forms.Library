using Library.Core.ViewModels;
using Library.Core.ViewModels.Books;
using Library.Core.Views;
using Library.Core.Views.Books;
using Library.DataAccess.Entities;
using Library.DataAccess.Repositories.BookRepository;
using Library.PlatformServices;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Prism.Unity;
using Unity;
using Unity.Injection;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Library
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/HomePage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //RegisterForNavigation
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<BooksPage,BooksPageViewModel>();
            containerRegistry.RegisterForNavigation<AddBookPage,AddBookPageViewModel>();
            //Register Types
            var databaseService = containerRegistry.GetContainer().Resolve<IDatabaseService>();
            databaseService.Connection.CreateTable<BookEntity>();

            containerRegistry.GetContainer().RegisterType<IBooksRepository, BooksDbRepository>();
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=15702a58-04b1-4fa5-8dee-8308fc2635d6;" +
                            "uwp={Your UWP App secret here};" +
                            "ios={Your iOS App secret here}",
                typeof(Analytics), typeof(Crashes));
        }
    }
}
