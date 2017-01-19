using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.core.welcome.Services;
using webapi.core.welcome.Models;

namespace webapi.core.welcome.Controllers
{
    [Route("api/[controller]")]
    public class BusinessController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: api/business
        [HttpGet]
        public IEnumerable<Business> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/business/5
        [HttpGet("{id}")]
        public Business Get(string id)
        {
            throw new NotImplementedException();
        }

        // POST api/business
        [HttpPost]
        public void Post([FromBody]Business business)
        {
            throw new NotImplementedException();
        }

        // PUT api/business
        [HttpPut("/")]
        public void Put([FromBody]Business business)
        {
            throw new NotImplementedException();
        }

        // DELETE api/business/5
        [HttpDelete("{id}")]
        public void Delete(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
