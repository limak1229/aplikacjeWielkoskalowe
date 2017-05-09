using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Interfaces;
using AppCore.Models;
using DataAccessLayer.DataBaseContext;
using DataAccessLayer.Interfaces;

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

        public Guid CalculateRoute(List<City> cities)
        {
            throw new NotImplementedException();
        }
    }
}
