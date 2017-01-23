using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using webapi.core.entityframework.DAL;
using webapi.core.entityframework.ModelMapped;
using webapi.core.entityframework.Models;

namespace webapi.core.entityframework.Services.Categories
{
    public class CategoryServices
    {
        public readonly UnitOfWork UnitOfWork;
        private readonly PagedCollectionParameters _defaultPagingOptions;
        private readonly TypeAdapterConfig _typeAdapterConfig;

        public CategoryServices(UnitOfWork UnitOfWork,
           IOptions<PagedCollectionParameters> defaultPagingOptions,
           TypeAdapterConfig typeAdapterConfig)
        {
            this.UnitOfWork = UnitOfWork;
            _defaultPagingOptions = defaultPagingOptions.Value;
            _typeAdapterConfig = typeAdapterConfig;
        }

        internal async Task<PagedCollection<CategoryMapped>> GetAllCategories(PagedCollectionParameters parameters)
        {
            var getAllQuery = new GetAllCategories(UnitOfWork, _defaultPagingOptions, _typeAdapterConfig, ENDPOINT.Category);
            var results = await getAllQuery.Execute(parameters);

            // Attach form definitions for discoverability
            results.Forms = new[] { Form.FromModel<BusinessCreateModel>(ENDPOINT.Business, "POST", "create-form") };

            return results;
        }

        internal IActionResult GetCategoryById(string Id)
        {
            var query = new GetCategory(UnitOfWork, _typeAdapterConfig);
            var post = query.Execute(Id);

            return post == null
                ? new NotFoundResult() as ActionResult
                : new ObjectResult(post);
        }

        internal IActionResult AddCategory(CategoryCreateModel model)
        {
            var createQuery = new CreateCategory(UnitOfWork, _typeAdapterConfig);
            var post = createQuery.Execute(model);

            return new CreatedAtRouteResult("default", new { controller = ENDPOINT.Business, id = post.Item1 }, post.Item2);
        }

        internal async Task<IActionResult> GetAllBusinessesByCategory(string categoryId, PagedCollectionParameters parameters)
        {
            var query = new GetBusinessesByCategory(UnitOfWork, _defaultPagingOptions, _typeAdapterConfig, ENDPOINT.Category);
            var posts = await query.Execute(categoryId, parameters);

            return posts == null
                ? new NotFoundResult() as ActionResult
                : new ObjectResult(posts);
        }
    }
}
