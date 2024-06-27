using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SuperShopMVVM.Models;
using SuperShopMVVM.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace SuperShopMVVM.ViewModels
{
    public class ProductsPageViewModel : ViewModelBase
    {
        // Atributes
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private ObservableCollection<ProductResponse> _products;
        private bool _isRunning;
        private string _search;
        private List<ProductResponse> _myProducts;
        private DelegateCommand _searchCommand;

        public ProductsPageViewModel(
            INavigationService navigationService,
            IApiService apiService
            ) : base(navigationService)
        {
            Title = "Product Page";
            _navigationService = navigationService;
            _apiService = apiService;
            LoadProductsAsync();
        }

        // Commands
        public DelegateCommand SearchCommand => _searchCommand ?? (_searchCommand = new DelegateCommand(ShowProducts));

        // Properties
        public string Search
        {
            get => _search;
            set
            {
                SetProperty(ref _search, value);
                ShowProducts();
            }
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public ObservableCollection<ProductResponse> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        // Methods
        private async void LoadProductsAsync()
        {
            //if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            //{
            //    Device.BeginInvokeOnMainThread(async () =>
            //    {
            //        await App.Current.MainPage.DisplayAlert("Error", "Check internet connection", "Accept");
            //    });
            //    return;
            //}

            IsRunning = true;

            string url = App.Current.Resources["UrlAPI"].ToString();

            Response response = await _apiService.GetListAsync<ProductResponse>(url, "/api", "/Products/GetProducts");

            IsRunning = false;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }
            _myProducts = (List<ProductResponse>)response.Result;
            ShowProducts();
        }

        private void ShowProducts()
        {
            if (string.IsNullOrEmpty(Search))
            {
                Products = new ObservableCollection<ProductResponse>(_myProducts);
            }
            else
            {
                Products = new ObservableCollection<ProductResponse>(_myProducts.Where(p => p.Name.ToLower().Contains(Search.ToLower())));
            }
        }


    }
}
