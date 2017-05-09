using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Interfaces;
using AppCore.Models;
using Newtonsoft.Json;

namespace AppCore.Managers
{
    public class RouteManager : IRouteManager
    { 
        public RouteManager()
        {
        }

        public List<City> GetRoute(Guid routeGuid)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> CalculateRoute(string version, string jsonString)
        {
            var data = JsonConvert.DeserializeObject<City>(jsonString);
            //:TODO Dorobić fabryke oboiektów po wersji jsona

            throw new NotImplementedException();
        }
    }
}
