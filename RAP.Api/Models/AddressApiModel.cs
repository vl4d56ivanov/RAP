using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAP.Api.Models
{
    public class AddressApiModel
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Home { get; set; }
        public string Flat { get; set; }
    }
}