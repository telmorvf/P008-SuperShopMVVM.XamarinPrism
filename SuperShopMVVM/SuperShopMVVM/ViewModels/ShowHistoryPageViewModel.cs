using Prism.Navigation;
using SuperShopMVVM.Helpers;

namespace SuperShopMVVM.ViewModels
{
    public class ShowHistoryPageViewModel : ViewModelBase
    {
        public ShowHistoryPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = Languages.ShowPurchaseHistory;
        }
    }
}
