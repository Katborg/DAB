using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.Models
{
    public class PersonDTO
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }
        public string AdressId { get; set; }
    }
}