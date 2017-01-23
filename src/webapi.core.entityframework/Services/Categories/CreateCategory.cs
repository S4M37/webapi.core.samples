using System;
using System.Threading.Tasks;
using Mapster;
using webapi.core.entityframework.ModelMapped;
using webapi.core.entityframework.DbModels;
using webapi.core.entityframework.DAL;

namespace webapi.core.entityframework.Services.Categories
{
    public class CreateCategory
    {
        private readonly UnitOfWork UnitOfWork;
        private readonly TypeAdapterConfig _typeAdapterConfig;

        public CreateCategory(UnitOfWork unitOfWork, TypeAdapterConfig typeAdapterConfig)
        {
            UnitOfWork = unitOfWork;
            _typeAdapterConfig = typeAdapterConfig;
        }

        public Tuple<string, CategoryMapped> Execute(CategoryCreateModel model)
        {
            var entry = UnitOfWork.CategoryRepository.add(new Category
            {
                Name = model.Name,
                CreatedAt = DateTime.UtcNow,
            });

            UnitOfWork.Save();

            return new Tuple<string, CategoryMapped>(
                entry.Entity.Id,
                entry.Entity.Adapt<CategoryMapped>(_typeAdapterConfig));
        }
    }
}
