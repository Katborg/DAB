using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace REST_API.Models
{
    public class City
    {
        [Key]
        public long CityId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ZipCode { get; set; }
    }
}