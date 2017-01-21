using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.core.entityframework.Models;

namespace webapi.core.entityframework.Services
{
    public class BusinessServices
    {
        public double getDistance(Business business,double lat, double lon)
        {
            //return 0;
            return Math.Sqrt(Math.Pow(lat - business.Lat, 2) + Math.Pow(lon - business.Lon, 2));
        }
    }
}
