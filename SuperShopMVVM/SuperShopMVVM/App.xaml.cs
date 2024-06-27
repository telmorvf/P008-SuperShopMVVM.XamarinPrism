using Prism;
using Prism.Ioc;
using SuperShopMVVM.Services;
using SuperShopMVVM.ViewModels;
using SuperShopMVVM.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace SuperShopMVVM
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/ProductsPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();

            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();

            containerRegistry.RegisterForNavigation<ProductsPage, ProductsPageViewModel>();
        }
    }
}
