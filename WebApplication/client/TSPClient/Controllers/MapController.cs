using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using TSPClientRepository.Interfaces;
using TSPClientRepository.Models;

namespace TSPClient.Controllers
{
    public class MapController : Controller
    {
        IMap mapService;
        public MapController(IMap mapService)
        {
            this.mapService = mapService;
        }
        public ActionResult Index()
        {
            return View(new List<City>());
        }
        [HttpPost]
        public ActionResult Index(object[] citiesArray)
        {
            mapService.ParseToList(citiesArray);
            return Content("<script language='javascript' type='text/javascript'>alert('Punkty zostały dodane. Kliknij '/Rysuj' aby zobaczyć trasę');</script>");
        }
        public async Task<ActionResult> ShowRoute(bool? token)
        {
            List<City> sortedList;
            if (token!= null && token.Value)
            {
                sortedList = TempData["SortedList"] as List<City>;
            }
            else
            {
                sortedList = await mapService.SortList(CityContainer.Instance().GetCities());
            }
            ViewBag.Token = UserSettings.Instance().token;
            return View(sortedList);
        }

        [HttpPost]
        public async Task<ActionResult> GetResultByToken(string token)
        {
            List<City> cities = await mapService.GetResultByToken(token);
            if(cities.Count > 0 )
            {
                TempData["SortedList"] = cities;
                return RedirectToAction("ShowRoute", new { token = true });
            }
            else
            {
                return View("BadToken");
            }
        }
    }
}