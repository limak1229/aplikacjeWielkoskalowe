using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Interfaces;
using AppCore.Models;
using AutoMapper;
using Newtonsoft.Json;

namespace AppCore
{
    public class BaseRouteCalculator : IRouteCalculator
    {
        private readonly TSP.TSP _algorythm;
        private readonly IMapper _mapper;

        public List<City> Cities { get; private set; }
        public Guid Token { get; private set; }

        public BaseRouteCalculator(TSP.TSP algorythm, IMapper mapper)
        {
            _algorythm = algorythm;
            _mapper = mapper;
        }

        public void SetData(Guid token, string data)
        {
            Cities = JsonConvert.DeserializeObject<List<City>>(data);
            Token = token;
        }

        public bool ValidateData()
        {
            return Cities != null && Cities.Any();
        }

        public async Task Calculate()
        {
            Task.Run(() =>
            {
                var mappedData = _mapper.Map<List<TSPEngine.City>>(Cities);
                _algorythm.CalculateRoute(Token, mappedData);
            });
        }

        public string GetResponseData()
        {
            return JsonConvert.SerializeObject(Cities);
        }
    }
}