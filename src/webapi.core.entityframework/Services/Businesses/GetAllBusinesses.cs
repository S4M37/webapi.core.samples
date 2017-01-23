using System.Threading.Tasks;
using Mapster;
using webapi.core.entityframework.ModelMapped;
using webapi.core.entityframework.Models;
using webapi.core.entityframework.DAL;

namespace webapi.core.entityframework.Services.Businesses
{
    public class GetAllBusinesses
    {
        private readonly UnitOfWork UnitOfWork;
        private readonly PagedCollectionParameters _defaultPagingParameters;
        private readonly TypeAdapterConfig _typeAdapterConfig;
        private readonly string _endpoint;

        public GetAllBusinesses(
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

        public Task<PagedCollection<BusinessMapped>> Execute(PagedCollectionParameters parameters)
        {
            var collectionFactory = new PagedCollectionFactory<BusinessMapped>(PlaceholderLink.ToCollection(_endpoint));

            return collectionFactory.CreateFrom(
                UnitOfWork.BusinessRepository.dbSet.ProjectToType<BusinessMapped>(_typeAdapterConfig),
                parameters.Offset ?? _defaultPagingParameters.Offset.Value,
                parameters.Limit ?? _defaultPagingParameters.Limit.Value);
        }
    }
}
