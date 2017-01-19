﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace webapi.core.mongo.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        // GET: /
        [HttpGet]
        public JsonResult Get()
        {
            var returnObject = new
            {
                DotnetVersion = ".NET Core V1.1.0",
                ServerStatus = "Green",
                Description = ".Net Core Project with Mongo Adapter connector",
                AvailableAPIs = "GET: /api/values"
            };

            return Json(returnObject);
        }

    }
}
