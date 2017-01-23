using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.EntityFrameworkCore;
using webapi.core.entityframework.Models;
using webapi.core.entityframework.ModelMapped;
using webapi.core.entityframework.DAL;

namespace webapi.core.entityframework.Services.Categories
{
    public class GetBusinessesByCategory
    {
        private readonly UnitOfWork UnitOfWork;
        private readonly PagedCollectionParameters _defaultPagingParameters;
        private readonly TypeAdapterConfig _typeAdapterConfig;
        private readonly string _endpoint;

        public GetBusinessesByCategory(
            UnitOfWork unitOfWork,
            PagedCollectionParameters defaultPagingParameters,
            TypeAdapterConfig typeAdapterConfig,
            string endpoint)
        {
            UnitOfWork = unitOfWork;
            _defaultPagingParameters = defaultPagingParameters;
            _typeAdapterConfig = typeAdapterConfig;
            _endpoint = endpoint;

        }

        public async Task<PagedCollection<BusinessMapped>> Execute(string categoryId, PagedCollectionParameters parameters)
        {
            var meta = PlaceholderLink.ToCollection(_endpoint, values: new { id = categoryId, link = ENDPOINT.Business });
            var collectionFactory = new PagedCollectionFactory<BusinessMapped>(meta);

            var category = await UnitOfWork.CategoryRepository.dbSet
                .Where(x => x.Id == categoryId)
                .SingleOrDefaultAsync();

            if (category == null)
            {
                return null;
            }

            var query = UnitOfWork.BusinessRepository.dbSet
                .Where(o => o.Id == categoryId)
                .ProjectToType<BusinessMapped>(_typeAdapterConfig);

            return await collectionFactory.CreateFrom(
                query,
                parameters.Offset ?? _defaultPagingParameters.Offset.Value,
                parameters.Limit ?? _defaultPagingParameters.Limit.Value);
        }
    }
}
