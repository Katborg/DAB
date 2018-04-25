using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace REST_API.Models
{
    public class Phone
    {
        [Key]
        public long PhoneID { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string provider { get; set; }
    }
}