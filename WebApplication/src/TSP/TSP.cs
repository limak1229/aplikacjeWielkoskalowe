using System;
using System.Collections.Generic;
using System.Linq;
using TSPEngine;

namespace TSP
{
    public class TSP
    {
        public List<City> getRoute(List<City> cities)
        {
            var stops = Enumerable.Range(1, cities.Count)
                                  .Select(i => new Stop(cities[i]))
                                  .NearestNeighbors()
                                  .ToList();


            stops.Connect(true);

            Tour startingTour = new Tour(stops);

            while (true)
            {
                var newTour = startingTour.GenerateMutations()
                                          .MinBy(tour => tour.Cost());
                if (newTour.Cost() < startingTour.Cost()) startingTour = newTour;
                else return newTour.Path();
            }
        }
    }
}
