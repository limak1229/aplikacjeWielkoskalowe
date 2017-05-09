using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Interfaces;
using AppCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    public class RouteController : Controller
    {
        private readonly IRouteManager _routeManager;

        public RouteController(IRouteManager routeManager)
        {
            _routeManager = routeManager;
        }

        [HttpPost]
        public IActionResult GetRoute(Guid routeGuid)
        {
            return Ok(_routeManager.GetRoute(routeGuid));
        }

        [HttpGet]
        public IActionResult CalculateRoute(List<City> cities)
        {
            return Ok(_routeManager.CalculateRoute(cities));
        }
    }
}
