using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Interfaces
{
    public interface IJsonRouteCalculatorCreator
    {
        RouteCalculator<string> GetRouteCalculator(string version);
    }
}
