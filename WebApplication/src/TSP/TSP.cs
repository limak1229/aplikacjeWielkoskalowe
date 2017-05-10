using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Interfaces;
using Newtonsoft.Json;
using TSPEngine;

namespace TSP
{
    public class Tsp
    {
        private readonly ICalculatedRoutesRepository _calculatedRoutesRepository;

        public Tsp(ICalculatedRoutesRepository calculatedRoutesRepository)
        {
            _calculatedRoutesRepository = calculatedRoutesRepository;
        }

        public void CalculateRoute(Guid token, List<City> cities)
        {
            var stops = Enumerable.Range(0, cities.Count)
                .Select(i => new Stop(cities[i]))
                .NearestNeighbors()
                .ToList();


            stops.Connect(true);

            var startingTour = new Tour(stops);

            while (true)
            {
                var newTour = startingTour.GenerateMutations().MinBy(tour => tour.Cost());

                _calculatedRoutesRepository.AddNewCalculatedRoute("1.0", token,
                    JsonConvert.SerializeObject(newTour.Path()));

                if (newTour.Cost() < startingTour.Cost())
                    startingTour = newTour;
                else
                    return;
            }
        }
    }
}