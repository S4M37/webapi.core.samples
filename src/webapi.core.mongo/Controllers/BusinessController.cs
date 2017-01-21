﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.core.mongo.DAL;
using webapi.core.mongo.Models;

namespace webapi.core.mongo.Controllers
{
    [Route("api/[controller]")]
    public class BusinessController : Controller
    {
        private UnitOfWork unitOfWork;

        public BusinessController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/business
        [HttpGet]
        public IEnumerable<Entity> Get()
        {
            return unitOfWork.BusinessRepository.GetAll();
        }

        // GET api/business/5
        [HttpGet("{id}")]
        public Entity Get(string id)
        {
            return unitOfWork.BusinessRepository.Get(id);
        }

        // POST api/business
        [HttpPost]
        public string Post([FromBody]Business business)
        {
            return unitOfWork.BusinessRepository.Add(business);
        }

        // PUT api/business
        [HttpPut]
        public void Put([FromBody]Business business)
        {
            unitOfWork.BusinessRepository.Update(business);
        }

        // DELETE api/business/5
        [HttpDelete("{id}")]
        public void Delete(string Id)
        {
            unitOfWork.BusinessRepository.Delete(Id);
        }
    }
}
