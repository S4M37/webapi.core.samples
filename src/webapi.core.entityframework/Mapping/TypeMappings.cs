using webapi.core.entityframework.ModelMapped;
using webapi.core.entityframework.DbModels;
using webapi.core.entityframework.Models;
using Mapster;

namespace webapi.core.entityframework.Services
{
    public class TypeMappings : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<Business, BusinessMapped>()
                .MapWith(src => new BusinessMapped
                {
                    Meta = PlaceholderLink.ToResource(ENDPOINT.Business, src.Id, "GET", null),
                    Category = PlaceholderLink.ToResource(ENDPOINT.Category, src.CategoryId, "GET", null),
                    Name = src.Name,
                    Id = src.Id,
                    Adress = src.Adress,
                    Distance = src.Distance,
                    UpdatedAt = src.UpdatedAt,
                    CreatedAt = src.CreatedAt
                });

            config.ForType<Category, CategoryMapped>()
                .MapWith(src => new CategoryMapped
                {
                    Meta = PlaceholderLink.ToResource(ENDPOINT.Category, src.Id, "GET", null),
                    Businesses = PlaceholderLink.ToCollection(ENDPOINT.Business, "GET", new { id = src.Id, link = ENDPOINT.Business }),
                    Name = src.Name,
                    Id = src.Id,
                    UpdatedAt = src.UpdatedAt,
                    CreatedAt = src.CreatedAt
                });
        }
    }
}

