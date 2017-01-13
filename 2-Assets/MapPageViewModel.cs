using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Template10.Mvvm;
using WhereAmI.Models;
using Windows.ApplicationModel;
using Windows.UI.Xaml.Navigation;

namespace WhereAmI.ViewModels
{
    /// <summary>
    /// 맵 뷰모델
    /// </summary>
    public class MapPageViewModel : ViewModelBase
    {
        #region Property

        /// <summary>
        /// 선택한 시티 정보
        /// </summary>
        private City _selectedCity;
        public City SelectedCity
        {
            get { return _selectedCity; }
            set { Set(ref _selectedCity, value); }
        }
        
        /// <summary>
        /// 지도 조회용 Uri
        /// </summary>
        private Uri _uri;
        public Uri Uri
        {
            get { return _uri; }
            set { Set(ref _uri, value); }
        }

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
            }
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

            //지도에 표시하기 위해서 좌표 따기
            if (string.IsNullOrEmpty(SelectedCity.Lat) || string.IsNullOrEmpty(SelectedCity.Lng)) return;

            var latIdx = SelectedCity.Lat.IndexOf('.');
            var lngIdx = SelectedCity.Lng.IndexOf('.');
            var lat = SelectedCity.Lat.Length > 0 ? SelectedCity.Lat.Substring(0, latIdx + 4) : "";
            var lng = SelectedCity.Lng.Length > 0 ? SelectedCity.Lng.Substring(0, lngIdx + 4) : "";

            //호출할 위치 입력
            Uri = new Uri($"http://www.geonames.org/maps/google_{lat}_{lng}.html");

            await Task.CompletedTask;
        }

        #endregion
    }
}

