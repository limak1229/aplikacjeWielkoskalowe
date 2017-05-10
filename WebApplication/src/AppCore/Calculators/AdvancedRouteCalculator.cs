using System;
using AutoMapper;
using TSP;

namespace AppCore.Calculators
{
    public class AdvancedRouteCalculator : BaseRouteCalculator
    {
        public AdvancedRouteCalculator(Tsp algorythm, IMapper mapper) : base(algorythm, mapper)
        {
        }

        public override bool IsValidInputData(string inputData)
        {
            Console.WriteLine("Do sth else");
            return base.IsValidInputData(inputData);
        }
    }
}