using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.core.entityframework.Services;
using webapi.core.entityframework.Models;
using Xunit;

namespace core.xunit.Test_Files
{
    public class TestBusiness
    {
        protected BusinessServices BusinessServices;
        protected Business businessTest;

        public TestBusiness()
        {
            BusinessServices = new BusinessServices();
            businessTest = new Business()
            {
                Id = "1",
                Name = "business test",
                Adress = "Tunis",
                Lat = 10,
                Lon = 0
            };
        }

        [Fact]
        public void TestGetDistance()
        {
            double expected = 10;
            double actual = BusinessServices.getDistance(businessTest, 0, 0);

            Assert.Equal(expected, actual);
        }
    }
}
