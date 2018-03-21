using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Handin22
{
    class Person
    {
        
        public string firstName {get; set;}
        public string middleName {get; set;}
        [Key]
        public string lastName {get; set;}
        public string type {get; set;}
        public List<Phone> phoneNumbers {get; set;}
        public Adress PAdress { get; set; }
        public List<Adress> AAdresses { get; set; }

    }
}
