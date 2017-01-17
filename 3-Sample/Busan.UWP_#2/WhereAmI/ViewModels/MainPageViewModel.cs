using Blend.SampleData.SampleDataSource;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Template10.Mvvm;
using WhereAmI.Models;
using Windows.ApplicationModel;
using Windows.UI.Xaml.Controls;

namespace WhereAmI.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Property

        /// <summary>
        /// ������ ����
        /// </summary>
        private ResultListItem _selectedCountry;
        public ResultListItem SelectedCountry
        {
            get { return _selectedCountry; }
            set { Set(ref _selectedCountry, value); }
        }

        /// <summary>
        /// �Է��� ���ø�
        /// </summary>
        private string _inputCity;
        public string InputCity
        {
            get { return _inputCity; }
            set { Set(ref _inputCity, value); }
        }

        /// <summary>
        /// �˻� ��� ���� ���
        /// </summary>
        private IList<City> _resultList;
        public IList<City> ResultList
        {
            get { return _resultList; }
            set { Set(ref _resultList, value); }
        }

        #endregion

        #region Command

        public DelegateCommand FindCommand { get; set; } //RaiseCanExecuteChanged ���
        public ICommand OpenMapCommand { get; set; }
        
        #endregion

        #region Constructor

        /// <summary>
        /// �⺻ ������
        /// </summary>
        public MainPageViewModel()
        {
            if (DesignMode.DesignModeEnabled)
            {
                //������ Ÿ�� ������
                InputCity = "���ø��� �Է����ּ���.";

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
                //��Ÿ�� 
                ResultList = new ObservableCollection<City>();

                Initialize();
            }
        }

        #endregion

        #region Method

        /// <summary>
        /// �ʱ�ȭ
        /// </summary>
        private void Initialize()
        {
            //�˻� Ŀ�ǵ� ����
            FindCommand = new DelegateCommand(async () =>
            {
                //TODO : �������� �˻��� ������ ��� ��������
                await AddDummyCityAsync();

            }, () => !string.IsNullOrEmpty(InputCity));

            //���� ���� Ŀ�ǵ� ����
            OpenMapCommand = new DelegateCommand<object>(obj =>
            {
                var args = obj as ItemClickEventArgs;
                var item = args?.ClickedItem as City;
                if (item == null) return;

                var serializeItem = JsonConvert.SerializeObject(item);
                NavigationService.Navigate(typeof(Views.MapPage), serializeItem);
            });

            //������Ƽ ü���� �̺�Ʈ �ڵ鷯
            PropertyChanged += (s, e) =>
            {
                switch (e.PropertyName)
                {
                    case "InputCity":
                        //������Ƽ�� ����Ǹ�, Ŀ�ǵ� ��� ���� ���θ� Ȯ��
                        FindCommand.RaiseCanExecuteChanged();
                        break;
                }
            };
        }

        /// <summary>
        /// ���� �˻���� ����
        /// </summary>
        /// <returns></returns>
        private async Task AddDummyCityAsync()
        {
            ResultList.Clear();

            //���� ��Ƽ ����
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
    }
}

