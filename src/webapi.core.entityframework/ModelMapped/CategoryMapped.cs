using System;
using webapi.core.entityframework.Models;

namespace webapi.core.entityframework.ModelMapped
{
    public class CategoryMapped : Resource
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime UpdatedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public ILink Businesses { get; set; }
    }
}
