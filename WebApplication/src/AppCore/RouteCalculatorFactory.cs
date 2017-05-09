using System;
using System.Collections.Generic;
using System.Text;
using AppCore.Interfaces;

namespace AppCore
{
    public class RouteCalculatorFactory
    {
        public IRouteCalculator GetRouteCalculator(string version);
    }
}
