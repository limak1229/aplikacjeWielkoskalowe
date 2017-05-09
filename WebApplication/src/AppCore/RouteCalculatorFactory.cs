using System;
using System.Collections.Generic;
using System.Text;
using AppCore.Interfaces;

namespace AppCore
{
    public class RouteCalculatorFactory
    {
        private readonly BaseRouteCalculator _baseRouteCalculator;
        private readonly AdvancedRouteCalculator _advancedRouteCalculator;

        public RouteCalculatorFactory(BaseRouteCalculator baseRouteCalculator, AdvancedRouteCalculator advancedRouteCalculator)
        {
            _baseRouteCalculator = baseRouteCalculator;
            _advancedRouteCalculator = advancedRouteCalculator;
        }

        public IRouteCalculator GetRouteCalculator(string version)
        {
            switch (version)
            {
                case "1.0":
                    return _baseRouteCalculator;
                case "2.0":
                    return _advancedRouteCalculator;
                default:
                    throw new Exception("Incorrect route calculator version");
            }
        }
    }
}
