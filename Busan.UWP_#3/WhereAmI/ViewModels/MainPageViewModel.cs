using Blend.SampleData.SampleDataSource;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Template10.Mvvm;
using WhereAmI.Models;
using WhereAmI.Services;
using Windows.ApplicationModel;
using Windows.UI.Xaml.Controls;

namespace WhereAmI.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Property

        /// <summary>
        /// 선택한 나라
        /// </summary>
        private ResultListItem _selectedCountry;
        public ResultListItem SelectedCountry
        {
            get { return _selectedCountry; }
            set { Set(ref _selectedCountry, value); }
        }

        /// <summary>
        /// 입력한 도시명
        /// </summary>
        private string _inputCity;
        public string InputCity
        {
            get { return _inputCity; }
            set { Set(ref _inputCity, value); }
        }

        /// <summary>
        /// 검색 결과 도시 목록
        /// </summary>
        private IList<City> _resultList;
        public IList<City> ResultList
        {
            get { return _resultList; }
            set { Set(ref _resultList, value); }
        }

        #endregion

        #region Command

        public DelegateCommand FindCommand { get; set; }
        public ICommand OpenMapCommand { get; set; }
        
        #endregion

        #region Constructor

        /// <summary>
        /// 기본 생성자
        /// </summary>
        public MainPageViewModel()
        {
            if (DesignMode.DesignModeEnabled)
            {
                //디자인 타임 데이터
                InputCity = "검색어를 입력해주세요.";
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
                //런타임 
                ResultList = new ObservableCollection<City>();

                Initialize();
            }
        }

        #endregion

        #region Method
        /// <summary>
        /// 초기화
        /// </summary>
        private void Initialize()
        {
            //검색 커맨드 생성
            FindCommand = new DelegateCommand(async () =>
            {
                ResultList.Clear();

                var result = await GeoNamesServiceHelper.Instance.GetGeonames(InputCity);
                if (result.geonames == null) return;

                foreach (var geoname in result.geonames)
                {
                    ResultList.Add(new City
                    {
                        CityName = geoname.name,
                        Lat = geoname.lat,
                        Lng = geoname.lng,
                        Population = geoname.population
                    });
                }
            }, () => !string.IsNullOrEmpty(InputCity));

            //지도 열기 커맨드 생성
            OpenMapCommand = new DelegateCommand<object>(obj =>
            {
                var args = obj as ItemClickEventArgs;
                var item = args?.ClickedItem as City;
                if (item == null) return;

                var serializeItem = JsonConvert.SerializeObject(item);
                NavigationService.Navigate(typeof(Views.MapPage), serializeItem);
            });

            //프로퍼티 체인지 이벤트 핸들러
            PropertyChanged += (s, e) =>
            {
                switch (e.PropertyName)
                {
                    case "InputCity":
                        //프로퍼티가 변경되면, 커맨드 사용 가능 여부를 확인
                        FindCommand.RaiseCanExecuteChanged();
                        break;
                }
            };
        }

        #endregion
    }
}

