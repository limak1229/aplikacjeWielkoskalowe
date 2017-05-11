using System;
using System.Collections.Generic;
using System.Linq;
using Algorythms.Interfaces;
using DataAccessLayer.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TSPEngine;

namespace Algorythms.Implementations
{
    public class Tsp : IAlgorythm<List<Place>>
    {
        private readonly ICalculatedRoutesRepository _calculatedRoutesRepository;

        public Tsp(ICalculatedRoutesRepository calculatedRoutesRepository)
        {
            _calculatedRoutesRepository = calculatedRoutesRepository;
        }

        public void CalculateRoute(Guid token, List<Place> cities)
        {
            var stops = Enumerable.Range(0, cities.Count)
                .Select(i => new Stop(cities[i]))
                .NearestNeighbors()
                .ToList();


            stops.Connect(true);

            var startingTour = new Tour(stops);
            AddNewCalculatedRoute(token, startingTour);

            while (true)
            {
                var newTour = startingTour.GenerateMutations().MinBy(tour => tour.Cost());
                if (newTour.Cost() < startingTour.Cost())
                {
                    startingTour = newTour;
                    AddNewCalculatedRoute(token, newTour);
                }
                else
                    return;
            }
        }

        private void AddNewCalculatedRoute(Guid token, Tour newTour)
        {
            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            _calculatedRoutesRepository.AddNewCalculatedRoute("1.0", token,
                JsonConvert.SerializeObject(newTour.Path(), settings));
        }
    }
}