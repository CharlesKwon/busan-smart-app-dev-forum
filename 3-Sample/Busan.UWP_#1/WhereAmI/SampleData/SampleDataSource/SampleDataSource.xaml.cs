﻿//      *********    DO NOT MODIFY THIS FILE     *********
//      This file is regenerated by a design tool. Making
//      changes to this file can cause errors.
namespace Blend.SampleData.SampleDataSource
{
    using System; 
    using System.ComponentModel;

// To significantly reduce the sample data footprint in your production application, you can set
// the DISABLE_SAMPLE_DATA conditional compilation constant and disable sample data at runtime.
#if DISABLE_SAMPLE_DATA
    internal class SampleDataSource { }
#else

    public class SampleDataSource : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public SampleDataSource()
        {
            try
            {
                Uri resourceUri = new Uri("ms-appx:/SampleData/SampleDataSource/SampleDataSource.xaml", UriKind.RelativeOrAbsolute);
                Windows.UI.Xaml.Application.LoadComponent(this, resourceUri);
            }
            catch
            {
            }
        }

        private ResultList _ResultList = new ResultList();

        public ResultList ResultList
        {
            get
            {
                return this._ResultList;
            }
        }

        private CountryList _CountryList = new CountryList();

        public CountryList CountryList
        {
            get
            {
                return this._CountryList;
            }
        }
    }

    public class ResultList : System.Collections.ObjectModel.ObservableCollection<ResultListItem>
    { 
    }

    public class ResultListItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string _CityName = string.Empty;

        public string CityName
        {
            get
            {
                return this._CityName;
            }

            set
            {
                if (this._CityName != value)
                {
                    this._CityName = value;
                    this.OnPropertyChanged("CityName");
                }
            }
        }

        private string _Lat = string.Empty;

        public string Lat
        {
            get
            {
                return this._Lat;
            }

            set
            {
                if (this._Lat != value)
                {
                    this._Lat = value;
                    this.OnPropertyChanged("Lat");
                }
            }
        }

        private string _Lng = string.Empty;

        public string Lng
        {
            get
            {
                return this._Lng;
            }

            set
            {
                if (this._Lng != value)
                {
                    this._Lng = value;
                    this.OnPropertyChanged("Lng");
                }
            }
        }

        private double _Population = 0;

        public double Population
        {
            get
            {
                return this._Population;
            }

            set
            {
                if (this._Population != value)
                {
                    this._Population = value;
                    this.OnPropertyChanged("Population");
                }
            }
        }
    }

    public class CountryList : System.Collections.ObjectModel.ObservableCollection<CountryListItem>
    { 
    }

    public class CountryListItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string _Country = string.Empty;

        public string Country
        {
            get
            {
                return this._Country;
            }

            set
            {
                if (this._Country != value)
                {
                    this._Country = value;
                    this.OnPropertyChanged("Country");
                }
            }
        }
    }
#endif
}
