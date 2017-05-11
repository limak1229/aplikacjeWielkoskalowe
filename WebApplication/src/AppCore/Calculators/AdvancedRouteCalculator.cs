using System;
using System.Collections.Generic;
using Algorythms.Interfaces;
using AutoMapper;
using DataAccessLayer.Interfaces;
using TSPEngine;

namespace AppCore.Calculators
{
    public class AdvancedRouteCalculator : BaseRouteCalculator
    {
        public AdvancedRouteCalculator(IAlgorythm<List<City>> algorythm, IMapper mapper, ICalculatedRoutesRepository calculatedRoutesRepository) : base(algorythm, mapper, calculatedRoutesRepository)
        {

        }

        public override bool IsValidInputData()
        {
            Console.WriteLine("Do sth else");
            return base.IsValidInputData();
        }
    }
}