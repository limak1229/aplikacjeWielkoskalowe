using System;
using AppCore.Interfaces;

namespace AppCore.Managers
{
    public class RouteManager<T> : IRouteManager<T>
    {
        private readonly RouteCalculator<T> _routeCalculator;

        public RouteManager(RouteCalculator<T> routeCalculator)
        {
            _routeCalculator = routeCalculator;
        }

        public T GetRouteData(Guid token)
        {
            _routeCalculator.SetOutputData(token);

            if (!_routeCalculator.IsValidOutputData())
                throw new Exception("Invalid output data.");

            return _routeCalculator.GetResponseData();
        }

        public Guid CalculateRoute(T data)
        {
            var token = _routeCalculator.GenerateToken();
            _routeCalculator.SetInputData(data);

            if (!_routeCalculator.IsValidInputData())
                throw new Exception("Invalid input data.");

            _routeCalculator.Calculate();

            return token;
        }
    }
}