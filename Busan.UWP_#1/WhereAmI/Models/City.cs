using System;
using Template10.Mvvm;

namespace WhereAmI.Models
{
    public class City : BindableBase
    {
        public string CityName { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public int Population { get; set; }

        public City()
        {
        }
    }
}
