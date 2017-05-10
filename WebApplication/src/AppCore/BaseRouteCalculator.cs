using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Interfaces;
using AppCore.Models;
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace AppCore
{
    public class BaseRouteCalculator : IRouteCalculator
    {
        private readonly TSP.TSP _algorythm;
        private readonly IMapper _mapper;

        private bool _isValid;

        public BaseRouteCalculator(TSP.TSP algorythm, IMapper mapper)
        {
            _algorythm = algorythm;
            _mapper = mapper;
            _isValid = false;
        }

        public List<City> Cities { get; private set; }
        public Guid Token { get; private set; }

        public void SetData(Guid token, string inputData)
        {
            if (!_isValid)
                return;

            Cities = JsonConvert.DeserializeObject<List<City>>(inputData);
            Token = token;
        }

        public bool IsValidData(string inputData)
        {
            if (string.IsNullOrEmpty(inputData))
                return _isValid = false;

            const string schemaJson = @"{
                'type': 'array',
                'cityName': {'type':'string'},
                'latitude': {'type':'double'},
                'longitude': {'type':'double'}
            }";

            var schema = JSchema.Parse(schemaJson);
            var data = JObject.Parse(inputData);

            if (!data.IsValid(schema))
                return _isValid = false;
            
            Cities = JsonConvert.DeserializeObject<List<City>>(inputData);
            if (Cities == null || !Cities.Any())
                return _isValid = false;

            var isDuplicatedCityEntry = Cities.Any(city => Cities.Count(c => c.CityName == city.CityName) != 1);

            return _isValid = !isDuplicatedCityEntry;
        }

        public async Task Calculate()
        {
            if (_isValid)
                Task.Run(() =>
                {
                    var mappedData = _mapper.Map<List<TSPEngine.City>>(Cities);
                    _algorythm.CalculateRoute(Token, mappedData);
                });
            else
                throw new Exception("Invalid data when trying calculate route.");
        }

        public string GetResponseData()
        {
            if (_isValid)
                return JsonConvert.SerializeObject(Cities);
            throw new Exception("Invalid data when trying get response data");
        }
    }
}