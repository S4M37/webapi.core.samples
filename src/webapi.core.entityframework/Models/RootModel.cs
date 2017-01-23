using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.core.entityframework.Controllers;

namespace webapi.core.entityframework.Models
{
    public class RootModel : Resource
    {
        public RootModel()
        {
            Meta = new PlaceholderLink()
            {
                Href = "/",
                Method = "GET"
            };
        }

        public ILink Businesses { get; set; } = PlaceholderLink.ToCollection(ENDPOINT.Business);

        public ILink Categories { get; set; } = PlaceholderLink.ToCollection(ENDPOINT.Category);

    }
}
