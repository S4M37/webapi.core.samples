using Mapster;
using webapi.core.entityframework.DAL;
using webapi.core.entityframework.ModelMapped;

namespace webapi.core.entityframework.Services.Categories
{
    public class GetCategory
    {
        private readonly UnitOfWork UnitOfWork;
        private readonly TypeAdapterConfig _typeAdapterConfig;

        public GetCategory(UnitOfWork unitOfWork, TypeAdapterConfig typeAdapterConfig)
        {
            UnitOfWork = unitOfWork;
            _typeAdapterConfig = typeAdapterConfig;
        }

        public CategoryMapped Execute(string id)
        {
            var category = UnitOfWork.CategoryRepository.get(id);

            return category?.Adapt<CategoryMapped>(_typeAdapterConfig);
        }
    }
}
