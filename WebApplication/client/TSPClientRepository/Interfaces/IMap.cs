using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSPClientRepository.Models;

namespace TSPClientRepository.Interfaces
{
    public interface IMap
    {
        Task<List<City>> SortList(List<City> cities);
        Task<List<City>> GetResultByToken(string token);
        void ParseToList(object[] citiesArray);
    }
}
