using Blend.SampleData.SampleDataSource;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Template10.Mvvm;
using WhereAmI.Models;
using Windows.ApplicationModel;
using Windows.UI.Xaml.Navigation;

namespace WhereAmI.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        // sample https://github.com/Windows-XAML/Template10/blob/master/Templates%20(Project)/Minimal/ViewModels/MainPageViewModel.cs

        #region Property

        private ResultListItem _selectedCountry;
        public ResultListItem SelectedCountry
        {
            get { return _selectedCountry; }
            set { Set(ref _selectedCountry, value); }
        }

        private string _inputCity;
        public string InputCity
        {
            get { return _inputCity; }
            set { Set(ref _inputCity, value); }
        }

        private ObservableCollection<City> _resultList;
        public ObservableCollection<City> ResultList
        {
            get { return _resultList; }
            set { Set(ref _resultList, value); }
        }

        private City _selectedCity;
        public City SelectedCity
        {
            get { return _selectedCity; }
            set { Set(ref _selectedCity, value); }
        }

        #endregion

        #region Command

        public DelegateCommand FindCommand { get; set; }
        public DelegateCommand OpenMapCommand { get; set; }
        
        #endregion

        #region Constructor

        public MainPageViewModel()
        {
            if (DesignMode.DesignModeEnabled)
            {
                InputCity = "도시명을 입력해주세요.";

                ResultList = new ObservableCollection<City>()
                {
                    new City { CityName = "Seoul", Lat="123.456", Lng="456.789", Population=123456789 },
                    new City { CityName = "Busan", Lat="456.789", Lng="123.456", Population=123456789 },
                    new City { CityName = "Seoul", Lat="123.456", Lng="456.789", Population=123456789 },
                    new City { CityName = "Busan", Lat="456.789", Lng="123.456", Population=123456789 },
                    new City { CityName = "Seoul", Lat="123.456", Lng="456.789", Population=123456789 },
                    new City { CityName = "Busan", Lat="456.789", Lng="123.456", Population=123456789 },
                };
            }
            else
            {
                ResultList = new ObservableCollection<City>();

                Initialize();
            }
        }

        #endregion

        #region Method

        private void Initialize()
        {
            FindCommand = new DelegateCommand(() =>
            {
                AddDummyCityAsync();

            }, () => !string.IsNullOrEmpty(InputCity));

            OpenMapCommand = new DelegateCommand(() =>
            {
                var item = SelectedCity;

                NavigationService.Navigate(typeof(Views.MapPage), item);

            }, () => SelectedCity != null);

            PropertyChanged += (s, e) =>
            {
                switch (e.PropertyName)
                {
                    case "InputCity":
                        FindCommand.RaiseCanExecuteChanged();
                        break;
                }
            };
        }

        private async void AddDummyCityAsync()
        {
            for (int i = 0; i < 10; i++)
            {
                ResultList.Add(new City
                {
                    CityName = "City Name " + i,
                    Lat = i + "111.111",
                    Lng = i + "222.222",
                    Population = 183653729 * (i + 1)
                });

                await Task.Delay(TimeSpan.FromMilliseconds(100));
            }
        }

        #endregion

        #region Public Method

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            SelectedCity = null;

            await Task.CompletedTask;
        }

        #endregion
    }
}

