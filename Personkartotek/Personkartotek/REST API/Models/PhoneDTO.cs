using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.Models
{
    public class PhoneDTO
    {
        public long PhoneID { get; set; }
        public string Number { get; set; }
        public string provider { get; set; }
    }
}