using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.core.welcome.Models;

namespace webapi.core.mongo.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        // GET: /
        [HttpGet]
        public JsonResult Get()
        {
            Business business = new Business
            {
                Id = "Id",
                Name = "BusinessName",
                Adress = "BusinessAdress"
            };
            IList<string> listAPIs = new List<string>();
            listAPIs.Add("GET: /api/values");
            listAPIs.Add("GET: /api/business");
            listAPIs.Add("GET: /api/business/{id}");
            listAPIs.Add("POST: /api/business" );
            listAPIs.Add("======> [FromBody]Business :" + business.ToString());
            listAPIs.Add("DelETE: /api/business/{id}");
            listAPIs.Add("PUT (update): /api/business/");

            var returnObject = new
            {
                DotnetVersion = ".NET Core V1.1.0",
                ServerStatus = "Green",
                Description = ".Net Core Project with Mongo Adapter connector",
                AvailableAPIs = listAPIs
            };

            return Json(returnObject);
        }

    }
}
