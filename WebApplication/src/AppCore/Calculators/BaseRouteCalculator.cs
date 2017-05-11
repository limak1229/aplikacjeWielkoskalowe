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
using TSP;

namespace AppCore.Calculators
{
    public class BaseRouteCalculator : RouteCalculator
    {
        private readonly Tsp _algorythm;
        private readonly IMapper _mapper;

        private bool _isValidInputData;
        private bool _isValidOutputData;

        public BaseRouteCalculator(Tsp algorythm, IMapper mapper)
        {
            _algorythm = algorythm;
            _mapper = mapper;
            _isValidInputData = false;
            _isValidOutputData = false;
        }

        public List<City> Cities { get; private set; }
        public Guid Token { get; private set; }

        public override void SetData(Guid token, string jsonData)
        {
            if (!_isValidInputData)
                return;

            Cities = JsonConvert.DeserializeObject<List<City>>(jsonData);
            Token = token;
        }

        public override bool IsValidInputData(string jsonData)
        {
            return _isValidInputData = IsValidJsonData(jsonData);
        }

        public override bool IsValidOutputData(string jsonData)
        {
            return _isValidOutputData = IsValidJsonData(jsonData);
        }

        public override async Task Calculate()
        {
            if (_isValidInputData)
                Task.Run(() =>
                {
                    var mappedData = _mapper.Map<List<TSPEngine.City>>(Cities);
                    _algorythm.CalculateRoute(Token, mappedData);
                });
            else
                throw new Exception("Invalid data when trying calculate route.");
        }

        public override string GetResponseData()
        {
            if (_isValidOutputData)
                return JsonConvert.SerializeObject(Cities);
            throw new Exception("Invalid output data when trying get response.");
        }

        private bool IsValidJsonData(string jsonData)
        {
            if (string.IsNullOrEmpty(jsonData))
                return false;

            const string schemaJson = @"{
                'type': 'array',
                'uniqueItems': true,
                'minItems': 3,
                'items': {
                    'type': 'object',
                    'properties': {
                        'cityName': {'type':'string'},
                        'latitude': {'type':'number', 'multipleOf': 0.00001, 'minimum': -85, 'maximum': 85},
                        'longitude': {'type':'number', 'multipleOf': 0.00001, 'minimum': -180, 'maximum': 180}
                     },
                    'required': ['cityName', 'latitude', 'longitude']
                }
            }";

            var schema = JSchema.Parse(schemaJson);
            var data = JArray.Parse(jsonData);
            var isValid = data.IsValid(schema);
            if (!isValid)
                return false;

            Cities = JsonConvert.DeserializeObject<List<City>>(jsonData);
            if (Cities == null || !Cities.Any())
                return false;

            var isDuplicatedCityEntry = Cities.Any(city => Cities.Count(c => c.CityName == city.CityName) != 1);

            return !isDuplicatedCityEntry;
        }
    }
}