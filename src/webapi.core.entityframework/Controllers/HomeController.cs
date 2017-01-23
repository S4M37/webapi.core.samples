using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.core.entityframework.Models;

namespace webapi.core.entityframework.Controllers
{
    [Route(ENDPOINT.Home)]
    public class HomeController : Controller
    {
        // GET: /
        [HttpGet]
        public IActionResult Get()
        {
            var returnObject = new
            {
                DotnetVersion = ".NET Core V1.1.0",
                ServerStatus = "Green",
                Description = ".Net Core Project with Entity Framework",
                AvailableAPIs = new RootModel()
            };
            return new ObjectResult(returnObject);
        }

    }
}
