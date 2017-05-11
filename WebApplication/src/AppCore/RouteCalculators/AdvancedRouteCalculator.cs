using System;
using System.Collections.Generic;
using Algorythms.Interfaces;
using DataAccessLayer.Interfaces;
using TSPEngine;

namespace AppCore.RouteCalculators
{
    public class AdvancedRouteCalculator : BaseRouteCalculator
    {
        public AdvancedRouteCalculator(IAlgorythm<List<City>> algorythm, ICalculatedRoutesRepository calculatedRoutesRepository) : base(algorythm, calculatedRoutesRepository)
        {

        }

        public override bool IsValidInputData()
        {
            Console.WriteLine("Do sth else");
            return base.IsValidInputData();
        }
    }
}