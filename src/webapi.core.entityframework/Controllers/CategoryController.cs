using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using webapi.core.entityframework.ModelMapped;
using webapi.core.entityframework.Models;
using webapi.core.entityframework.Services.Categories;

namespace webapi.core.entityframework.Controllers
{
    [Route(ENDPOINT.Category)]
    public class CategoryController : Controller
    {
        public CategoryServices CategoryServices;

        public CategoryController(CategoryServices categoryServices)
        {
            CategoryServices = categoryServices;
        }


        [HttpGet]
        public async Task<IActionResult> Get(PagedCollectionParameters parameters)
        {
            var results = await CategoryServices.GetAllCategories(parameters);
            return new ObjectResult(results);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(string id)
        {
            return CategoryServices.GetCategoryById(id);
        }

        [HttpGet]
        [Route("{id}/business")]
        public async Task<IActionResult> GetBusinesses(string id, PagedCollectionParameters parameters)
        {
            var result = await CategoryServices.GetAllBusinessesByCategory(id, parameters);
            return result;
        }

        [HttpPost]
        public IActionResult Post([FromBody]CategoryCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    code = 400,
                    message = ModelState.Values.First().Errors.First().ErrorMessage
                });
            }

            return CategoryServices.AddCategory(model);
        }
    }
}
