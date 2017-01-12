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
    /// �� ���
    /// </summary>
    public class MapPageViewModel : ViewModelBase
    {
        #region Property

        private City _selectedCity;
        /// <summary>
        /// ������ ��Ƽ ����
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
        /// �⺻ ������
        /// </summary>
        public MapPageViewModel()
        {
            if (DesignMode.DesignModeEnabled)
            {
                //������ Ÿ�� ������
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
                //��Ÿ��
                InitializeMap();
            }
        }

        #endregion

        #region Private Method
        /// <summary>
        /// ���� ��ȸ�� Uri
        /// </summary>
        public Uri Uri
        {
            get { return _uri; }
            set { Set(ref _uri, value); }
        }
        /// <summary>
        /// �ʱ�ȭ
        /// </summary>
        private void InitializeMap()
        {
        }

        #endregion

        #region Public Method
        /// <summary>
        /// �׺����Ʈ �Ϸ�
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="mode"></param>
        /// <param name="suspensionState"></param>
        /// <returns></returns>
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            //���޵� city ������ SelectedCity�� �Է�
            var para = parameter?.ToString();
            if (string.IsNullOrEmpty(para)) return;

            SelectedCity = JsonConvert.DeserializeObject<City>(para);

            Uri = new Uri("http://www.geonames.org/maps/google_35.159_129.161.html");

            await Task.CompletedTask;
        }

        #endregion
    }
}

