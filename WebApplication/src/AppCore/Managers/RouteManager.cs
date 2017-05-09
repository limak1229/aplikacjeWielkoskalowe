using System;
using AppCore.Interfaces;
using DataAccessLayer.Interfaces;

namespace AppCore.Managers
{
    public class RouteManager : IRouteManager
    {
        private readonly ICalculatedRoutesRepository _calculatedRoutesRepository;
        private readonly RouteCalculatorFactory _calculatorFactory;

        public RouteManager(ICalculatedRoutesRepository calculatedRoutesRepository,
            RouteCalculatorFactory calculatorFactory)
        {
            _calculatedRoutesRepository = calculatedRoutesRepository;
            _calculatorFactory = calculatorFactory;
        }

        public string GetRouteData(Guid token)
        {
            var calculatedRoute = _calculatedRoutesRepository.GetCalculatedRoutes(token);
            if (calculatedRoute == null || string.IsNullOrEmpty(calculatedRoute.DataVersion) || string.IsNullOrEmpty(calculatedRoute.Data))
                throw new ArgumentException("Incorrect calculated route data.");

            var calculator = _calculatorFactory.GetRouteCalculator("1.0");
            calculator.SetData(token, calculatedRoute.Data);
            return calculator.GetResponseData();
        }

        public Guid CalculateRoute(string version, string jsonString)
        {
            if (string.IsNullOrEmpty(version) || string.IsNullOrEmpty(jsonString))
                throw new ArgumentException("Incorrect input route data.");

            var token = Guid.NewGuid();
            var calculator = _calculatorFactory.GetRouteCalculator(version);
            calculator.SetData(token, jsonString);
            calculator.Calculate();

            return token;
        }
    }
}