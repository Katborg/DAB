using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace REST_API.Models
{
    public class Adress
    {
        [Key]
        public long AdressId { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Number { get; set; }
    }
}