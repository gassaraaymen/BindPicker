using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BindablePicker.Controls.ViewModel
{
    public class PickerMVVMViewModel : INotifyPropertyChanged
    {

        public List<City> CitiesList { get; set; }


        private City _selectedCity { get; set; }
        public  City SelectedCity
        {
            get { return _selectedCity; }
            set
            {
                if(_selectedCity != value)
                {
                    _selectedCity = value;
                    MyCity = "Selected City" + _selectedCity.Value;
                }
            }
        }


        private string _myCity { get; set; }
        public string MyCity
        {
            get { return _myCity; }
            set
            {
                if (_myCity != value)
                {
                    _myCity = value;
                    OnPropertyChanged();

                }
            }
        }

        public PickerMVVMViewModel()
        {
            CitiesList = GetCities().OrderBy(t => t.Value).ToList();
        }

        public List<City>GetCities()
        {
            var cities = new List<City>()
            {
                new City(){Key = 1 , Value ="Mumbai"},
                new City(){Key = 2 , Value ="Sfax"},
                new City(){Key = 3 , Value ="Paris"},
                new City(){Key = 4 , Value ="London"},
                new City(){Key = 5 , Value ="NewYork"}             
            };
            return cities;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            changed?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

    public class City
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

 
}

