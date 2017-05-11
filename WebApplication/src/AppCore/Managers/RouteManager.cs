using System;
using AppCore.Interfaces;
using DataAccessLayer.Interfaces;

namespace AppCore.Managers
{
    public class RouteManager : IRouteManager
    {
        private readonly ICalculatedRoutesRepository _calculatedRoutesRepository;
        private readonly IRouteCalculatorCreator _calculatorCreator;

        public RouteManager(ICalculatedRoutesRepository calculatedRoutesRepository, IRouteCalculatorCreator calculatorCreator)
        {
            _calculatedRoutesRepository = calculatedRoutesRepository;
            _calculatorCreator = calculatorCreator;
        }

        public string GetRouteData(Guid token)
        {
            var calculatedRoute = _calculatedRoutesRepository.GetCalculatedRoute(token);

            if (calculatedRoute == null)
                throw new ArgumentException("Missing calculated route data fetched from database.");
            if (string.IsNullOrEmpty(calculatedRoute.DataVersion) || string.IsNullOrEmpty(calculatedRoute.Data))
                throw new ArgumentException("Missing data version or calculated route data.");

            var calculator = _calculatorCreator.GetRouteCalculator(calculatedRoute.DataVersion);
            if (!calculator.IsValidOutputData(calculatedRoute.Data))
                throw new Exception("Invalid json data fetched from database");

            calculator.SetData(token, calculatedRoute.Data);

            return calculator.GetResponseData();
        }

        public Guid CalculateRoute(string version, string jsonString)
        {
            if (string.IsNullOrEmpty(version) || string.IsNullOrEmpty(jsonString))
                throw new ArgumentException("Missing data version or input route json data.");

            var calculator = _calculatorCreator.GetRouteCalculator(version);
            if (!calculator.IsValidInputData(jsonString))
                throw new Exception("Invalid input json data");

            var token = Guid.NewGuid();
            calculator.SetData(token, jsonString);
            calculator.Calculate();

            return token;
        }
    }
}