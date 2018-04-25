using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.Models
{
    public class AdressDTO
    {
        public long AdressId { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
    }
}