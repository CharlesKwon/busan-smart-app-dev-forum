using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Template10.Mvvm;
using WhereAmI.Models;
using Windows.ApplicationModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace WhereAmI.ViewModels
{
    public class MapPageViewModel : ViewModelBase
    {
        #region Property

        private City _selectedCity;
        public City SelectedCity
        {
            get { return _selectedCity; }
            set { Set(ref _selectedCity, value); }
        }

        private object _wEB;
        public object Web
        {
            get { return _wEB; }
            set { Set(ref _wEB, value); }
        }

        #endregion

        #region Constructor

        public MapPageViewModel()
        {
            if (DesignMode.DesignModeEnabled)
            {
                SelectedCity = new City()
                {
                    CityName = "City Name 00",
                    Lat = "123.456",
                    Lng = "456.789",
                    Population = 183653729
                };
            }
            else
            {
                InitializeMap();
            }
        }

        #endregion

        #region Private Method
        
        private void InitializeMap()
        {
            Web = new WebView();
            var broswer = Web as WebView;
            broswer.HorizontalAlignment = HorizontalAlignment.Stretch;
            broswer.VerticalAlignment = VerticalAlignment.Stretch;
            broswer.Loaded += Browser_Loaded;
        }

        private void Browser_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //해운대해수욕장
            var webView = sender as WebView;

            webView.Navigate(new Uri("http://www.geonames.org/maps/google_35.159_129.161.html"));
        }

        #endregion

        #region Public Method

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            SelectedCity = parameter as City;

            await Task.CompletedTask;
        }

        #endregion
    }
}

