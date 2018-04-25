using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.Models
{
    public class CityDTO
    {
        public long CityId { get; set; }
        public string Name { get; set; }
        public int ZipCode { get; set; }
    }
}