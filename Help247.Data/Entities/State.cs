﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Data.Entities
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CountryId { get; set; }
        public string CountryCode { get; set; }
    }
}
