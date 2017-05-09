using System;
using System.IO;
using System.Threading.Tasks;
using AppCore.Interfaces;
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

        [HttpGet]
        public IActionResult GetRoute(Guid routeGuid)
        {
            return Ok(_routeManager.GetRoute(routeGuid));
        }

        [HttpPost]
        public async Task<IActionResult> CalculateRoute([FromQuery] string version)
        {
            if (string.IsNullOrEmpty(version))
            {
                throw new ArgumentException("Missing request version.");
            }

            StreamReader reader = new StreamReader(this.Request.Body);
            string jsonString = reader.ReadToEnd();
            
            return Ok(await _routeManager.CalculateRoute(version, jsonString));
        }
    }
}
