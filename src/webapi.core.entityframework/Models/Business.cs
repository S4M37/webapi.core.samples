﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.core.welcome.Models
{
    public class Business
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public DateTime Timestamp { get; set; }
        public DateTime UpdatedTimestamp { get; set; }

    }
}
