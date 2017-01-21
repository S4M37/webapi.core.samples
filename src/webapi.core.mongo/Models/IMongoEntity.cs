using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.core.mongo.Models
{
    interface IMongoEntity<TId>
    {
        TId Id { get; set; }
    }
}
