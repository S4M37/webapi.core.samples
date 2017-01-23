using Mapster;
using webapi.core.entityframework.ModelMapped;
using webapi.core.entityframework.DAL;

namespace webapi.core.entityframework.Services.Businesses
{
    public class GetBusiness
    {
        private readonly UnitOfWork UnitOfWork;
        private readonly TypeAdapterConfig _typeAdapterConfig;

        public GetBusiness(UnitOfWork unitOfWork, TypeAdapterConfig typeAdapterConfig)
        {
            UnitOfWork = unitOfWork;
            _typeAdapterConfig = typeAdapterConfig;
        }

        public BusinessMapped Execute(string id)
        {
            var business = UnitOfWork.BusinessRepository.get(id);

            return business?.Adapt<BusinessMapped>(_typeAdapterConfig);
        }
    }
}
