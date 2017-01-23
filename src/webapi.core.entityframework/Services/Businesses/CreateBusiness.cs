using System;
using System.Threading.Tasks;
using Mapster;
using webapi.core.entityframework.DAL;
using webapi.core.entityframework.ModelMapped;
using webapi.core.entityframework.DbModels;

namespace webapi.core.entityframework.Services.Businesses
{
    public class CreateBusiness
    {
        private readonly UnitOfWork UnitOfWork;
        private readonly TypeAdapterConfig _typeAdapterConfig;

        public CreateBusiness(UnitOfWork unitOfWork, TypeAdapterConfig typeAdapterConfig)
        {
            UnitOfWork = unitOfWork;
            _typeAdapterConfig = typeAdapterConfig;
        }

        public Tuple<string, BusinessMapped> Execute(BusinessCreateModel model)
        {
            var entry = UnitOfWork.BusinessRepository.add(new Business
            {
                CategoryId = model.CategoryId,
                Name = model.Name,
                Adress = model.Adress,
                X = model.X,
                Y = model.Y,
                CreatedAt = DateTime.UtcNow
            });

            UnitOfWork.Save();

            return new Tuple<string, BusinessMapped>(
                entry.Entity.Id,
                entry.Entity.Adapt<BusinessMapped>(_typeAdapterConfig));
        }
    }
}
