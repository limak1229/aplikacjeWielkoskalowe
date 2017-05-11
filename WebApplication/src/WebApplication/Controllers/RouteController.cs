using System;
using System.IO;
using AppCore;
using AppCore.Interfaces;
using AppCore.Managers;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    public class RouteController : Controller
    {
        private readonly IJsonRouteCalculatorCreator _jsonRouteCalculatorCreator;

        public RouteController(IJsonRouteCalculatorCreator jsonRouteCalculatorCreator)
        {
            _jsonRouteCalculatorCreator = jsonRouteCalculatorCreator;
        }

        [HttpGet("{routeGuid}")]
        public IActionResult GetRoute(Guid routeGuid, [FromQuery] string version)
        {
            try
            {
                var routeCalculator = _jsonRouteCalculatorCreator.GetRouteCalculator(version);
                var routeManager = new RouteManager<string>(routeCalculator);
                var result = routeManager.GetRouteData(routeGuid);

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

                var routeCalculator = _jsonRouteCalculatorCreator.GetRouteCalculator(version);
                var routeManager = new RouteManager<string>(routeCalculator);

                var reader = new StreamReader(Request.Body);
                var jsonString = reader.ReadToEnd();

                return Ok(routeManager.CalculateRoute(jsonString));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}