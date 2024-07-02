using Prism.Navigation;
using SuperShopMVVM.Helpers;

namespace SuperShopMVVM.ViewModels
{
    public class ShowCartPageViewModel : ViewModelBase
    {
        public ShowCartPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = Languages.ShowShoppingCar;
        }
    }
}
