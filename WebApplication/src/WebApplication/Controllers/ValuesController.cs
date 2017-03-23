using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ITestManager _testManager;

        public ValuesController(ITestManager testManager)
        {
            _testManager = testManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_testManager.GetTestValues());
        }
    }
}
