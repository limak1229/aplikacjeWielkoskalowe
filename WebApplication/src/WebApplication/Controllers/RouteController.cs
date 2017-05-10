using System;
using System.IO;
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

        [HttpGet("{routeGuid}")]
        public IActionResult GetRoute(Guid routeGuid)
        {
            try
            {
                var result = _routeManager.GetRouteData(routeGuid);
                Response.ContentType = "application/json";
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult CalculateRoute([FromQuery] string version)
        {
            try
            {
                if (string.IsNullOrEmpty(version))
                    throw new ArgumentException("Missing request version.");

                var reader = new StreamReader(Request.Body);
                var jsonString = reader.ReadToEnd();

                return Ok(_routeManager.CalculateRoute(version, jsonString));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}