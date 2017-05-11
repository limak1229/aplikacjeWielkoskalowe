using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorythms.Interfaces;
using AppCore.Interfaces;
using DataAccessLayer.DataBaseContext;
using DataAccessLayer.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using TSPEngine;


namespace AppCore.RouteCalculators
{
    public class BaseRouteCalculator : RouteCalculator<string>
    {
        private readonly IAlgorythm<List<TSPEngine.City>> _algorythm;
        private readonly ICalculatedRoutesRepository _calculatedRoutesRepository;

        private bool _isValidInputData;
        private bool _isValidOutputData;

        private string _inputData;
        private CalculatedRoutes _outputData;
        private Guid _token;

        public BaseRouteCalculator(IAlgorythm<List<TSPEngine.City>> algorythm, ICalculatedRoutesRepository calculatedRoutesRepository)
        {
            _algorythm = algorythm;
            _calculatedRoutesRepository = calculatedRoutesRepository;

            _isValidInputData = false;
            _isValidOutputData = false;
        }

        public override Guid GenerateToken()
        {
            _token = Guid.NewGuid();
            return _token;
        }

        public override void SetInputData(string data)
        {
            _inputData = data;
        }

        public override void SetOutputData(Guid token)
        {
            _outputData = _calculatedRoutesRepository.GetCalculatedRoute(token);
        }

        public override bool IsValidInputData()
        {
            return _isValidInputData = IsValidJsonData(_inputData);
        }

        public override bool IsValidOutputData()
        {
            if (_outputData == null)
                return _isValidOutputData = false;

            return _isValidOutputData = IsValidJsonData(_outputData.Data);
        }

        public override async Task Calculate()
        {
            if (_isValidInputData)
                Task.Run(() =>
                {
                    var cities = JsonConvert.DeserializeObject<List<City>>(_inputData);
                    _algorythm.CalculateRoute(_token, cities);
                });
            else
                throw new Exception("Invalid data when trying calculate route.");
        }

        public override string GetResponseData()
        {
            if (_isValidOutputData)
                return JsonConvert.SerializeObject(_outputData.Data);
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

            var cities = JsonConvert.DeserializeObject<List<City>>(jsonData);
            if (cities == null || !cities.Any())
                return false;

            var isDuplicatedCityEntry = cities.Any(city => cities.Count(c => c.CityName == city.CityName) != 1);

            return !isDuplicatedCityEntry;
        }
    }
}