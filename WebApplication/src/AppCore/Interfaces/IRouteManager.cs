using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Models;
using DataAccessLayer.DataBaseContext;

namespace AppCore.Interfaces
{
    public interface IRouteManager
    {
        List<City> GetRoute(Guid routeGuid);
        Task<Guid> CalculateRoute(string version, string jsonString);
    }
}
