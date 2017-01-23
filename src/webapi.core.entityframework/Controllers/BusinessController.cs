using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using webapi.core.entityframework.DbModels;
using webapi.core.entityframework.ModelMapped;
using webapi.core.entityframework.Models;
using webapi.core.entityframework.Services.Businesses;

namespace webapi.core.entityframework.Controllers
{
    [Route(ENDPOINT.Business)]
    public class BusinessController : Controller
    {
        BusinessServices BusinessServices;

        public BusinessController(BusinessServices BusinessServices)
        {
            this.BusinessServices = BusinessServices;
        }

        // GET: api/business
        [HttpGet]
        public async Task<IActionResult> Get(PagedCollectionParameters parameters)
        {
            var result = await BusinessServices.GetAllBusinesses(parameters);
            return new ObjectResult(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(string id)
        {
            return BusinessServices.GetBusinessById(id);
        }

        public IActionResult Post([FromBody] BusinessCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    code = 400,
                    message = ModelState.Values.First().Errors.First().ErrorMessage
                });
            }

            var createdModel = BusinessServices.AddBusiness(model);

            return createdModel;
        }

        // PUT api/business
        [HttpPut]
        public void Put([FromBody]Business business)
        {
            BusinessServices.UnitOfWork.BusinessRepository.update(business);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            BusinessServices.UnitOfWork.BusinessRepository.delete(id);
        }
    }
}
