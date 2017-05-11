using System;
using AppCore.Calculators;
using AppCore.Interfaces;

namespace AppCore
{
    public class RouteCalculatorCreator: IRouteCalculatorCreator
    {
        private readonly AdvancedRouteCalculator _advancedRouteCalculator;
        private readonly BaseRouteCalculator _baseRouteCalculator;

        public RouteCalculatorCreator(BaseRouteCalculator baseRouteCalculator,
            AdvancedRouteCalculator advancedRouteCalculator)
        {
            _baseRouteCalculator = baseRouteCalculator;
            _advancedRouteCalculator = advancedRouteCalculator;
        }

        public RouteCalculator GetRouteCalculator(string version)
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