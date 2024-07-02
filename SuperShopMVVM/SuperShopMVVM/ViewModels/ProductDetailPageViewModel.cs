using Prism.Navigation;
using SuperShopMVVM.Models;

namespace SuperShopMVVM.ViewModels
{
    public class ProductDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private ProductResponse _product;

        public ProductDetailPageViewModel(
            INavigationService navigationService
            )
            : base(navigationService)
        {
            _navigationService = navigationService;
        }

        public ProductResponse Product
        {
            get => _product;
            set => SetProperty(ref _product, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("product"))
            {
                Product = parameters.GetValue<ProductResponse>("product");
                Title = Product.Name;
            }
        }
    }
}
