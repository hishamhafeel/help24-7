using System;
using System.Collections.Generic;
using System.Text;

namespace Help247.Service.BO.Country
{
    public class CountryBO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Iso3 { get; set; }
        public string Iso2 { get; set; }
        public string PhoneCode { get; set; }
        public string Capital { get; set; }
        public string Currency { get; set; }
    }
}
