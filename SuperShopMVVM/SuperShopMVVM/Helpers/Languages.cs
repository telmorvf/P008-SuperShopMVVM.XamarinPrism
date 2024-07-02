using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using SuperShopMVVM.Interfaces;
using SuperShopMVVM.Resources;
using Xamarin.Forms;

namespace SuperShopMVVM.Helpers
{
    public static class Languages
    {
        static Languages()
        {
            CultureInfo ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();

            Resource.Culture = ci;
            Culture = ci.Name;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }
        
        public static string Accept => Resource.Accept;
        public static string AddToCart => Resource.AddToCart;
        public static string Culture { get; set; }
        public static string ConnectionError => Resource.ConnectionError;
        public static string Error => Resource.Error;
        public static string IsAvailable => Resource.IsAvailable;
        public static string LastPurchase => Resource.LastPurchase;
        public static string LastSale => Resource.LastSale;
        public static string Login => Resource.Login;
        public static string Loading => Resource.Loading;
        public static string ModifyUser => Resource.ModifyUser;
        public static string Name => Resource.Name;
        public static string Product => Resource.Product;
        public static string Products => Resource.Products;
        public static string ProductsPage => Resource.ProductsPage;
        public static string Price => Resource.Price;
        public static string SearchProduct => Resource.SearchProduct;
        public static string Stock => Resource.Stock;
        public static string ShowPurchaseHistory => Resource.ShowPurchaseHistory;
        public static string ShowShoppingCar => Resource.ShowShoppingCar;
    }
}
