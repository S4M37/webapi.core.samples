using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.core.entityframework.Models;

namespace webapi.core.entityframework.Services
{
    public class BusinessServices
    {
        public double getDistance(Business business,double X, double Y)
        {
            //return 0;
            return Math.Sqrt(Math.Pow(X - business.X, 2) + Math.Pow(Y - business.Y, 2));
        }
    }
}
