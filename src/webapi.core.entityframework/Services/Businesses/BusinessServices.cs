using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using webapi.core.entityframework.DAL;
using webapi.core.entityframework.DbModels;
using webapi.core.entityframework.ModelMapped;
using webapi.core.entityframework.Models;

namespace webapi.core.entityframework.Services.Businesses
{
    public class BusinessServices
    {
        public UnitOfWork UnitOfWork { get; set; }


        private readonly PagedCollectionParameters _defaultPagingOptions;
        private readonly TypeAdapterConfig _typeAdapterConfig;

        public BusinessServices(UnitOfWork UnitOfWork,
           IOptions<PagedCollectionParameters> defaultPagingOptions,
           TypeAdapterConfig typeAdapterConfig)
        {
            this.UnitOfWork = UnitOfWork;
            _defaultPagingOptions = defaultPagingOptions.Value;
            _typeAdapterConfig = typeAdapterConfig;
        }

        public double getDistance(Business business, double X, double Y)
        {
            //return 0;
            return Math.Sqrt(Math.Pow(X - business.X, 2) + Math.Pow(Y - business.Y, 2));
        }

        internal async Task<PagedCollection<BusinessMapped>> GetAllBusinesses(PagedCollectionParameters parameters)
        {
            var getAllQuery = new GetAllBusinesses(UnitOfWork, _defaultPagingOptions, _typeAdapterConfig, ENDPOINT.Business);
            var results = await getAllQuery.Execute(parameters);

            // Attach form definitions for discoverability
            results.Forms = new[] { Form.FromModel<BusinessCreateModel>(ENDPOINT.Business, "POST", "create-form") };

            return results;
        }

        internal IActionResult GetBusinessById(string Id)
        {
            var query = new GetBusiness(UnitOfWork, _typeAdapterConfig);
            var post = query.Execute(Id);

            return post == null
                ? new NotFoundResult() as ActionResult
                : new ObjectResult(post);
        }

        internal IActionResult AddBusiness(BusinessCreateModel model)
        {
            var createQuery = new CreateBusiness(UnitOfWork, _typeAdapterConfig);
            var post = createQuery.Execute(model);

            return new CreatedAtRouteResult("default", new { controller = ENDPOINT.Business, id = post.Item1 }, post.Item2);
        }
    }
}
