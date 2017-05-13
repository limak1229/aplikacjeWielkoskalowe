using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Services;
using TSPClientRepository.Classes;
using TSPClientRepository.Interfaces;
using TSPClientRepository.Models;

namespace TSPClientRepository.Services
{
    public class Map : IMap
    {
        public async Task<List<City>> SortList(List<City> cities)
        {
            string token = await WebApi.PostMarkers(cities);
            if(!String.IsNullOrEmpty(token))
            {
                List<City> sortedCities = await WebApi.GetMarkers(token);
                return sortedCities;
            }
            else
            {
                throw new Exception("Błąd przy wywoływaniu metody");
            }
        }
        public async Task<List<City>> GetResultByToken(string token)
        {
            List<City> sortedCities = await WebApi.GetMarkers(token);
            return sortedCities;
        }
        public void ParseToList(object[] citiesArray)
        {
            CityContainer.Instance().Clear();
            for (int i = 0; i < citiesArray.Length; i += 3)
            {
                City city = new City(citiesArray[i].ToString(), Decimal.Parse(citiesArray[i + 1].ToString()), Decimal.Parse(citiesArray[i + 2].ToString()));
            }
        }
    }
}