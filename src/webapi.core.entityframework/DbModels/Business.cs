using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.core.entityframework.DbModels
{
    public class Business
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Distance { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CategoryId { get; set; }

    }
}
