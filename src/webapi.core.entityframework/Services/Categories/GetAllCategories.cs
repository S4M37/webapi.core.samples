using System.Threading.Tasks;
using Mapster;
using webapi.core.entityframework.Models;
using webapi.core.entityframework.ModelMapped;
using webapi.core.entityframework.DAL;

namespace webapi.core.entityframework.Services.Categories
{
    public class GetAllCategories
    {
        private readonly UnitOfWork UnitOfWork;
        private readonly PagedCollectionParameters _defaultPagingParameters;
        private readonly TypeAdapterConfig _typeAdapterConfig;
        private readonly string _endpoint;

        public GetAllCategories(
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

        public Task<PagedCollection<CategoryMapped>> Execute(PagedCollectionParameters parameters)
        {
            var collectionFactory = new PagedCollectionFactory<CategoryMapped>(PlaceholderLink.ToCollection(_endpoint));

            return collectionFactory.CreateFrom(
                UnitOfWork.CategoryRepository.dbSet.ProjectToType<CategoryMapped>(_typeAdapterConfig),
                parameters.Offset ?? _defaultPagingParameters.Offset.Value,
                parameters.Limit ?? _defaultPagingParameters.Limit.Value);
        }
    }
}
