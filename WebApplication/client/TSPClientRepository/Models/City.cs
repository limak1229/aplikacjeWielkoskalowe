using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSPClientRepository.Models
{
    public class City
    {
        public String cityName { get; set; }
        public Decimal latitude { get; set; }
        public Decimal longitude { get; set; }

        public City()
        {
            
        }
        public City(String CityName, Decimal Latitude, Decimal Longitude)
        {
            this.cityName = CityName;
            this.latitude = Decimal.Round(Latitude,2);
            this.longitude = Decimal.Round(Longitude,2);
            CityContainer.Instance().Add(this);
        }
        public City GetCity()
        {
            return this;
        }
    }
    public class CityContainer
    {
        private static CityContainer instance;
        private List<City> cities;
        private CityContainer()
        {
            cities = new List<City>();
        }
        public static CityContainer Instance()
        {
            if (instance == null)
            {
                instance = new CityContainer();
            }
            return instance;
        }
        public List<City> GetCities()
        {
            List<City> cities = new List<City>();
            cities.AddRange(Instance().cities);
            Instance().cities.Clear();
            return cities;
        }
        public void Add(City city)
        {
            Instance().cities.Add(city);
        }
        public void Clear()
        {
            Instance().cities.Clear();
        }
    }
}