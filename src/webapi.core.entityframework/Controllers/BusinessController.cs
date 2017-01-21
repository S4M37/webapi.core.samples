using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.core.entityframework.Services;
using webapi.core.welcome.Models;

namespace webapi.core.entityframework.Controllers
{
    [Route("api/[controller]")]
    public class BusinessController : Controller
    {
        public BusinessController(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public UnitOfWork UnitOfWork { get; set; }

        // GET: api/business
        [HttpGet]
        public IEnumerable<Business> Get()
        {
            return UnitOfWork.BusinessRepository.getAll();
        }

        // GET api/business/5
        [HttpGet("{id}")]
        public Business Get(string id)
        {
            return UnitOfWork.BusinessRepository.get(id);
        }

        // POST api/business
        [HttpPost]
        public void Post([FromBody]Business business)
        {
            UnitOfWork.BusinessRepository.add(business);
        }

        // PUT api/business
        [HttpPut]
        public void Put([FromBody]Business business)
        {
            UnitOfWork.BusinessRepository.update(business);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            UnitOfWork.BusinessRepository.delete(id);
        }
    }
}
