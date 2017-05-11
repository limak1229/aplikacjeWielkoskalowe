using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Interfaces
{
    public interface IRouteCalculatorCreator
    {
        RouteCalculator GetRouteCalculator(string version);
    }
}
