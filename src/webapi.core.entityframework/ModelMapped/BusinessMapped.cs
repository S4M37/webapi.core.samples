using System;
using webapi.core.entityframework.Models;

namespace webapi.core.entityframework.ModelMapped
{
    public class BusinessMapped : Resource
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Distance { get; set; }

        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public ILink Category { get; set; }
    }
}
