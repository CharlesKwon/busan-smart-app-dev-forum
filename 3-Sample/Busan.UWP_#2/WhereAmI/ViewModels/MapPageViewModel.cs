using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Template10.Mvvm;
using WhereAmI.Models;
using Windows.ApplicationModel;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;

namespace WhereAmI.ViewModels
{
    /// <summary>
    /// 맵 뷰모델
    /// </summary>
    public class MapPageViewModel : ViewModelBase
    {
        #region Property

        private City _selectedCity;
        /// <summary>
        /// 선택한 시티 정보
        /// </summary>
        public City SelectedCity
        {
            get { return _selectedCity; }
            set { Set(ref _selectedCity, value); }
        }

        private Uri _uri;

        #endregion

        #region Constructor
        /// <summary>
        /// 기본 생성자
        /// </summary>
        public MapPageViewModel()
        {
            if (DesignMode.DesignModeEnabled)
            {
                //디자인 타임 데이터
                SelectedCity = new City()
                {
                    CityName = "City Name 00",
                    Lat = "123.456",
                    Lng = "456.789",
                    Population = 183653729
                };
                Uri = new Uri("http://www.geonames.org/maps/google_35.159_129.161.html");
            }
            else
            {
                //런타임
                InitializeMap();
            }
        }

        #endregion

        #region Private Method
        /// <summary>
        /// 지도 조회용 Uri
        /// </summary>
        public Uri Uri
        {
            get { return _uri; }
            set { Set(ref _uri, value); }
        }
        /// <summary>
        /// 초기화
        /// </summary>
        private void InitializeMap()
        {
        }

        #endregion

        #region Public Method
        /// <summary>
        /// 네비게이트 완료
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="mode"></param>
        /// <param name="suspensionState"></param>
        /// <returns></returns>
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            //전달된 city 정보를 SelectedCity에 입력
            var para = parameter?.ToString();
            if (string.IsNullOrEmpty(para)) return;

            SelectedCity = JsonConvert.DeserializeObject<City>(para);

            Uri = new Uri("http://www.geonames.org/maps/google_35.159_129.161.html");

            await Task.CompletedTask;
        }

        #endregion
    }
}

